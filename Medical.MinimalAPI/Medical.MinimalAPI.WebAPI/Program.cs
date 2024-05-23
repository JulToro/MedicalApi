using Medical.MinimalAPI.WebAPI.Application.Controllers;
using Medical.MinimalAPI.WebAPI.Domain.Interfaces;
using Medical.MinimalAPI.WebAPI.Infrastructure;
using Medical.MinimalAPI.WebAPI.Presentation.Middleware;
using Npgsql;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddScoped<IDbConnection>(_ => new NpgsqlConnection(connectionString));
builder.Services.AddScoped<IMedicalRepository, MedicalContext>();

builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies((typeof(Program).Assembly)));

builder.Services.AddCors();

builder.Services.AddAutoMapper(typeof(Program)); 


var app = builder.Build();

app.UseCors(policy =>
{
    policy.AllowAnyOrigin();
    policy.AllowAnyHeader();
    policy.AllowAnyMethod();
});

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Medical API V1");
        c.RoutePrefix = string.Empty;
    });
}
app.UseMiddleware<ExceptionHandlingMiddleware>();

//app.UseHttpsRedirection();
app.AddMedicalEndpoints();

app.MapGet("/throw", () =>
{
    throw new Exception("This is a test exception.");
});

app.Run();
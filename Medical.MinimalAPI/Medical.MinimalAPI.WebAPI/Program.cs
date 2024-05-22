using Medical.MinimalAPI.WebAPI.Controllers;
using Medical.MinimalAPI.WebAPI.Infrastructure.Queries;
using Medical.MinimalAPI.WebAPI.Middleware;
using Npgsql;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddSingleton<IDbConnection>(_ => new NpgsqlConnection(connectionString));
builder.Services.AddScoped<IMedicalQueryContext, MedicalQueryContext>();

// Injection mediatR
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies((typeof(Program).Assembly)));

var app = builder.Build();

// Configure the HTTP request pipeline.
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

app.UseHttpsRedirection();
app.AddMedicalEndpoints();

app.MapGet("/throw", () =>
{
    throw new Exception("This is a test exception.");
});

app.Run();
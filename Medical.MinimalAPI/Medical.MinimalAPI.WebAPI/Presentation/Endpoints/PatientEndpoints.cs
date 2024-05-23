using AutoMapper;
using MediatR;
using Medical.MinimalAPI.WebAPI.Application.DTO;
using Medical.MinimalAPI.WebAPI.Domain.Queries.Patients.GetPatients;

namespace Medical.MinimalAPI.WebAPI.Application.Controllers
{
    public static class PatientEndpoints
    {
        public static void AddMedicalEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/patient", GetOrders);
        }

        private static async Task GetOrders(HttpContext context, IMediator _mediator, IMapper mapper)
        {
            var query = new GetPatientsQuery();
            var result = await _mediator.Send(query);

            await context.Response.WriteAsJsonAsync(mapper.Map<PatientDTO>(result));
        }
    }
}

using MediatR;
using Medical.MinimalAPI.WebAPI.Queries.Patients.GetPatients;

namespace Medical.MinimalAPI.WebAPI.Controllers
{
    public static class PatientEndpoints
    {
        public static void AddMedicalEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapGet("/patient", GetOrders);
        }

        private static async Task GetOrders(HttpContext context, IMediator _mediator)
        {
            var query = new GetPatientsQuery();
            var result = await _mediator.Send(query);
            await context.Response.WriteAsJsonAsync(result);
        }
    }
}

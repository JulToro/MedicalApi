using MediatR;
using Medical.MinimalAPI.WebAPI.Application.DTO;
using Medical.MinimalAPI.WebAPI.Domain.Models;

namespace Medical.MinimalAPI.WebAPI.Domain.Queries.Patients.GetPatients
{
    public class GetPatientsQuery : IRequest<IEnumerable<PatientInformation>>
    {

    }
}

using MediatR;
using Medical.MinimalAPI.WebAPI.DTO;
using Medical.MinimalAPI.WebAPI.Models;

namespace Medical.MinimalAPI.WebAPI.Queries.Patients.GetPatients
{
    public class GetPatientsQuery: IRequest<IEnumerable<PatientDTO>>
    {

    }
}

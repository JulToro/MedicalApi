using Medical.MinimalAPI.WebAPI.DTO;
using Medical.MinimalAPI.WebAPI.Models;

namespace Medical.MinimalAPI.WebAPI.Infrastructure.Queries
{
    public interface IMedicalQueryContext
    {
        Task<IEnumerable<PatientEncounterResult>> GetPatientEncounterAsync();
    }
}

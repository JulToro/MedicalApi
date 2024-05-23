using Medical.MinimalAPI.WebAPI.Domain.Models;

namespace Medical.MinimalAPI.WebAPI.Domain.Interfaces
{
    public interface IMedicalRepository
    {
        Task<IEnumerable<PatientEncounterResult>> GetPatientEncounterAsync();
    }
}

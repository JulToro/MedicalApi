using MediatR;
using Medical.MinimalAPI.WebAPI.Application.DTO;
using Medical.MinimalAPI.WebAPI.Domain.Interfaces;
using Medical.MinimalAPI.WebAPI.Domain.Models;

namespace Medical.MinimalAPI.WebAPI.Domain.Queries.Patients.GetPatients
{
    public class GetPatientsQueryHandler : IRequestHandler<GetPatientsQuery, IEnumerable<PatientInformation>>
    {
        protected readonly IMedicalRepository _medicalContext;
        public GetPatientsQueryHandler(IMedicalRepository medicalContext)
        {
            _medicalContext = medicalContext;
        }

        public async Task<IEnumerable<PatientInformation>> Handle(GetPatientsQuery request, CancellationToken cancellationToken)
        {
            var patientEncounterResults = await _medicalContext.GetPatientEncounterAsync();

            var groupedPatients = patientEncounterResults
                .GroupBy(pe => new { pe.PatientId, pe.FirstName, pe.LastName, pe.Age })
                .Where(g => g.Select(pe => pe.PayerCity).Distinct().Count() >= 2)
                .OrderBy(g => g.Count())
                .Select(g => new PatientInformation{
                    FullName = $"{g.Key.LastName}, {g.Key.FirstName}", 
                    VisitedCities = string.Join(", ", g.Select(pe => pe.FacilityCity).Distinct()) ,
                    Category= g.Key.Age < 16 ? "A" : "B"
                }                    
                )
                .ToList();



            return groupedPatients;
        }
    }
}

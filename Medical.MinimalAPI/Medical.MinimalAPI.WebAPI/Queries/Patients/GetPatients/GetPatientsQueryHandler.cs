using MediatR;
using Medical.MinimalAPI.WebAPI.DTO;
using Medical.MinimalAPI.WebAPI.Infrastructure.Queries;

namespace Medical.MinimalAPI.WebAPI.Queries.Patients.GetPatients
{
    public class GetPatientsQueryHandler : IRequestHandler<GetPatientsQuery, IEnumerable<PatientDTO>>
    {
        protected readonly IMedicalQueryContext _medicalContext;
        public GetPatientsQueryHandler(IMedicalQueryContext medicalContext)
        {
            _medicalContext = medicalContext;
        }

        public async Task<IEnumerable<PatientDTO>> Handle(GetPatientsQuery request, CancellationToken cancellationToken)
        {
            var patientEncounterResults = await _medicalContext.GetPatientEncounterAsync();

            var groupedPatients = patientEncounterResults
                .GroupBy(pe => new { pe.PatientId, pe.FirstName, pe.LastName, pe.Age })
                .Where(g => g.Select(pe => pe.PayerCity).Distinct().Count() >= 2)
                .OrderBy(g => g.Count())
                .Select(g => new PatientDTO(
                    FullName: $"{g.Key.LastName}, {g.Key.FirstName}",
                    VisitedCities: string.Join(", ", g.Select(pe => pe.FacilityCity).Distinct()),
                    Category: g.Key.Age < 16 ? "A" : "B"
                ))
                .ToList();

            return groupedPatients;
        }
    }
}

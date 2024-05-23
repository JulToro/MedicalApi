namespace Medical.MinimalAPI.WebAPI.Domain.Models
{
    public class PatientEncounterResult
    {
        public int PatientId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int Age { get; set; }
        public string? FacilityCity { get; set; }
        public string? PayerCity { get; set; }
        public int EncounterId { get; set; }
    }
}

using Dapper;
using Medical.MinimalAPI.WebAPI.Domain.Interfaces;
using Medical.MinimalAPI.WebAPI.Domain.Models;
using Npgsql;
using System.Data;

namespace Medical.MinimalAPI.WebAPI.Infrastructure
{
    public class MedicalContext : IMedicalRepository, IDisposable
    {
        private readonly IDbConnection _dbConnection;

        public MedicalContext(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<IEnumerable<PatientEncounterResult>> GetPatientEncounterAsync()
        {
            string sql = @"
                SELECT 
                    p.id AS PatientId,
                    p.first_name AS FirstName,
                    p.last_name AS LastName,
                    p.age AS Age,
                    f.city AS FacilityCity,
                    pa.city AS PayerCity,
                    e.id AS EncounterId
                FROM patients p
                INNER JOIN encounters e ON p.id = e.patient_id
                INNER JOIN facilities f ON e.facility_id = f.id
                INNER JOIN payers pa ON e.payer_id = pa.id
            ";

            return await _dbConnection.QueryAsync<PatientEncounterResult>(sql);
        }

        public void Dispose()
        {
            _dbConnection.Dispose();
        }

    }
}

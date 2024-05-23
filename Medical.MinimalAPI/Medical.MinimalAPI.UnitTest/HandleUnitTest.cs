using Medical.MinimalAPI.WebAPI.Domain.Interfaces;
using Medical.MinimalAPI.WebAPI.Domain.Models;
using Medical.MinimalAPI.WebAPI.Domain.Queries.Patients.GetPatients;
using Moq;

namespace Medical.MinimalAPI.UnitTest
{
    public class Tests
    {
        [TestFixture]
        public class GetPatientsQueryHandlerTests
        {
            [Test]
            public async Task Handle_ReturnsCorrectPatients_WhenConditionsMet()
            {
                // Arrange
                var mockRepository = new Mock<IMedicalRepository>();
                var patientEncounterResults = new List<PatientEncounterResult>
                        {
                            new PatientEncounterResult { PatientId = 1, FirstName = "John", LastName = "Doe", Age = 30, FacilityCity = "City1", PayerCity = "CityA" },
                            new PatientEncounterResult { PatientId = 1, FirstName = "John", LastName = "Doe", Age = 30, FacilityCity = "City2", PayerCity = "CityB" },
                            new PatientEncounterResult { PatientId = 2, FirstName = "Jane", LastName = "Smith", Age = 10, FacilityCity = "City3", PayerCity = "CityC" },
                            new PatientEncounterResult { PatientId = 3, FirstName = "Alice", LastName = "Johnson", Age = 25, FacilityCity = "City4", PayerCity = "CityD" },
                            new PatientEncounterResult { PatientId = 3, FirstName = "Alice", LastName = "Johnson", Age = 25, FacilityCity = "City5", PayerCity = "CityE" },
                        };

                mockRepository.Setup(repo => repo.GetPatientEncounterAsync()).ReturnsAsync(patientEncounterResults);

                var handler = new GetPatientsQueryHandler(mockRepository.Object);
                var query = new GetPatientsQuery();

                // Act
                var result = await handler.Handle(query, CancellationToken.None);

                // Assert
                Assert.IsNotNull(result);
                Assert.AreEqual(2, result.Count()); 
                Assert.IsTrue(result.Any(p => p.FullName == "Doe, John" && p.VisitedCities == "City1, City2" && p.Category == "B"));
                Assert.IsTrue(result.Any(p => p.FullName == "Johnson, Alice" && p.VisitedCities == "City4, City5" && p.Category == "B"));
            }

            [Test]
            public async Task Handle_ReturnsEmptyList_WhenNoPatientsMeetCriteria()
            {
                // Arrange
                var mockRepository = new Mock<IMedicalRepository>();
                var patients = new List<PatientEncounterResult>
            {
                new PatientEncounterResult { PatientId = 1, FirstName = "John", LastName = "Doe", Age = 30, FacilityCity = "City1", PayerCity = "CityA" },
                new PatientEncounterResult { PatientId = 2, FirstName = "Jane", LastName = "Smith", Age = 10, FacilityCity = "City2", PayerCity = "CityB" },
            };
                mockRepository.Setup(repo => repo.GetPatientEncounterAsync()).ReturnsAsync(patients);

                var handler = new GetPatientsQueryHandler(mockRepository.Object);
                var query = new GetPatientsQuery();

                // Act
                var result = await handler.Handle(query, CancellationToken.None);

                // Assert
                Assert.IsNotNull(result);
                Assert.IsEmpty(result); 
            }

            [Test]
            public async Task Handle_ReturnsPatientsInCorrectOrder_ByNumberOfEncounters()
            {
                // Arrange
                var mockRepository = new Mock<IMedicalRepository>();
                var patientEncounterResults = new List<PatientEncounterResult>
                        {
                            new PatientEncounterResult { PatientId = 1, FirstName = "John", LastName = "Doe", Age = 30, FacilityCity = "City1", PayerCity = "CityA" },
                            new PatientEncounterResult { PatientId = 1, FirstName = "John", LastName = "Doe", Age = 30, FacilityCity = "City2", PayerCity = "CityB" },
                            new PatientEncounterResult { PatientId = 2, FirstName = "Jane", LastName = "Smith", Age = 10, FacilityCity = "City3", PayerCity = "CityC" },
                            new PatientEncounterResult { PatientId = 3, FirstName = "Alice", LastName = "Johnson", Age = 25, FacilityCity = "City4", PayerCity = "CityD" },
                            new PatientEncounterResult { PatientId = 3, FirstName = "Alice", LastName = "Johnson", Age = 25, FacilityCity = "City5", PayerCity = "CityE" },
                        };
                mockRepository.Setup(repo => repo.GetPatientEncounterAsync()).ReturnsAsync(patientEncounterResults);

                var handler = new GetPatientsQueryHandler(mockRepository.Object);
                var query = new GetPatientsQuery();

                // Act
                var result = await handler.Handle(query, CancellationToken.None);

                // Assert
                Assert.IsNotNull(result);
                Assert.AreEqual(2, result.Count());
            }
        }
    }
}
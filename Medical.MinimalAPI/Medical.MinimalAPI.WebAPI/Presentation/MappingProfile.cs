using AutoMapper;
using Medical.MinimalAPI.WebAPI.Application.DTO;
using Medical.MinimalAPI.WebAPI.Domain.Models;

namespace Medical.MinimalAPI.WebAPI.Presentation
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PatientDTO, PatientInformation>();
        }
    }
}

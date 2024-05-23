using AutoMapper;
using Medical.MinimalAPI.WebAPI.Application.DTO;
using Medical.MinimalAPI.WebAPI.Domain.Models;

namespace Medical.MinimalAPI.WebAPI.Presentation
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PatientInformation, PatientDTO>()
            .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FullName))
            .ForMember(dest => dest.VisitedCities, opt => opt.MapFrom(src => src.VisitedCities))
            .ForMember(dest => dest.Category, opt => opt.MapFrom(src => src.Category))
            // Añade más mapeos de propiedades si es necesario
            .ReverseMap(); // Para mapeo bidireccional

        }
    }
}

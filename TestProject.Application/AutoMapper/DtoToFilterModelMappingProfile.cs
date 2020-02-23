using TestProject.Application.DTOs.Filters;
using TestProject.Domain.Models;
using AutoMapper;

namespace TestProject.Application.AutoMapper
{
    public class DtoToFilterModelMappingProfile : Profile
    {
        public DtoToFilterModelMappingProfile()
        {
            CreateMap<PersonFilterDTO, PersonFilter>()
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City.Name))
                .ForMember(dest => dest.PhoneNumber, opt => opt.MapFrom(src => src.PhoneNumbers.Number))
                .ForMember(dest => dest.PhoneNumberType, opt => opt.MapFrom(src => src.PhoneNumbers.Type));
        }
    }
}

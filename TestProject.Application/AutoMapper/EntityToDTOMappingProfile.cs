using AutoMapper;
using TestProject.Application.DTOs.City;
using TestProject.Application.DTOs.Person;
using TestProject.Application.DTOs.PhoneNumber;
using TestProject.Application.DTOs.RelativePerson;
using TestProject.Domain.Entities;

namespace TestProject.Application.AutoMapper
{
    public class EntityToDTOMappingProfile : Profile
    {
        public EntityToDTOMappingProfile()
        {
            CreateMap<PersonEntity, PersonWithRelativeDTO>()
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City.Name));

            CreateMap<PersonEntity, PersonDTO>()
                .ForMember(dest => dest.City, opt => opt.MapFrom(src => src.City.Name));

            CreateMap<RelatedPersonEntity, RelatedRelationDTO>()
                .ForMember(dest => dest.Person, opt => opt.MapFrom(src => src.RelatedPerson));

            CreateMap<PhoneNumberEntity, PhoneNumberDTO>();
            CreateMap<CityEntity, CityDTO>();
        }
    }
}

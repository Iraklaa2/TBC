using AutoMapper;
using TestProject.Application.DTOs.Person;
using TestProject.Application.DTOs.PhoneNumber;
using TestProject.Domain.Entities;

namespace TestProject.Application.AutoMapper
{
    public class DtoToEntityMappingProfile : Profile
    {
        public DtoToEntityMappingProfile()
        {
            CreateMap<CreatePersonDTO, PersonEntity>();
            CreateMap<AddPhoneNumberDTO, PhoneNumberEntity>();
        }
    }
}

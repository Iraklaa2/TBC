using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestProject.Application.Contracts;
using TestProject.Application.DTO.Requests;
using TestProject.Application.DTO.Responses;
using TestProject.Application.DTOs.Filters;
using TestProject.Application.DTOs.Person;
using TestProject.Application.DTOs.Requests;
using TestProject.Application.DTOs.Search;
using TestProject.Domain.Contracts;
using TestProject.Domain.Entities;
using TestProject.Domain.Models;

namespace TestProject.Application.Services
{
    public class PersonService : BasePersonService, IPersonService
    {
        private readonly IImageService _imageService;

        private readonly ICityService _cityService;

        private readonly IPhoneNumberRepository _phoneNumberRepository;

        public PersonService(IMapper mapper, IPersonRepository personRepository, IUnitOfWork unitOfWork, IImageService imageService, ICityService cityService, IPhoneNumberRepository phoneNumberRepository) 
            : base(unitOfWork, mapper, personRepository)
        {
            _imageService = imageService;
            _cityService = cityService;
            _phoneNumberRepository = phoneNumberRepository;
        }

        public ListViewDTO<PersonWithRelativeDTO> GetPersonsViaFastSearch(ListReuqestDTO<FastSearchDTO> requestParams)
        {
            IEnumerable<PersonEntity> persons;
            int totalRecords;

            if (requestParams.Filter.Value.All(char.IsDigit))
            {
                persons = _personRepository.SearchByPersonalNumber(requestParams.Filter.Value, requestParams.Page, requestParams.Limit, out totalRecords);
            }
            else
            {
                persons = _personRepository.SearchByFullName(requestParams.Filter.Value, requestParams.Page, requestParams.Limit, out totalRecords);
            }

            return new ListViewDTO<PersonWithRelativeDTO>
            {
                Data = Mapper.Map<IEnumerable<PersonWithRelativeDTO>>(persons),
                TotalRecords = totalRecords
            };
        }
        
        public ListViewDTO<PersonWithRelativeDTO> GetAll(ListReuqestDTO<PersonFilterDTO> requestParams)
        {
            var personsEntities = _personRepository.GetAll(requestParams.Filter, requestParams.Page, requestParams.Limit, out var totalRecords);

            return new ListViewDTO<PersonWithRelativeDTO>
            {
                Data = Mapper.Map<IEnumerable<PersonWithRelativeDTO>>(personsEntities),
                TotalRecords = totalRecords
            };
        }

        public DomainStatusCodes GetFullDataById(int personId, out PersonWithRelativeDTO person)
        {
            var personEntity = _personRepository.GetFullDataById(personId);
            person = null;

            if (personEntity == null)
                return DomainStatusCodes.RecordNotFound;

            person = Mapper.Map<PersonWithRelativeDTO>(personEntity);

            return DomainStatusCodes.Success;
        }

        public DomainStatusCodes GetFullDataByPersonalNumber(string personalNumber, out PersonWithRelativeDTO person)
        {
            var personEntity = _personRepository.GetFullDataByPersonalNumber(personalNumber);
            person = null;

            if (personEntity == null)
                return DomainStatusCodes.RecordNotFound;

            person = Mapper.Map<PersonWithRelativeDTO>(personEntity);

            return DomainStatusCodes.Success;
        }

        public DomainStatusCodes CreatePeron(CreatePersonDTO personData)
        {
            if (CheckIfPersonExistsByPersonalNumber(personData.PersonalNumber, out _))
                return DomainStatusCodes.UniqueViolation;

            if (!_cityService.CheckIfCityExists(personData.CityId, out var _))
                return DomainStatusCodes.RecordNotFound;

            var person = Mapper.Map<PersonEntity>(personData);

            _personRepository.Add(person);

            Commit();

            return DomainStatusCodes.Success;
        }

        public DomainStatusCodes UpdatePerson(int personId, CreatePersonDTO personData)
        {
            if (!CheckIfPersonExists(personId, out var existingPerson))
                return DomainStatusCodes.RecordNotFound;

            if (CheckIfPersonExistsByPersonalNumber(personData.PersonalNumber, out var existingPerson2) && existingPerson2.Id != personId)
                return DomainStatusCodes.UniqueViolation;

            existingPerson.LastName = personData.LastName;
            existingPerson.PersonalNumber = personData.PersonalNumber;
            existingPerson.CityId = personData.CityId;
            existingPerson.Gender = personData.Gender;
            existingPerson.DateOfBirth = personData.DateOfBirth;
            existingPerson.FirstName = personData.FirstName;
            
            _phoneNumberRepository.RemovePersonsPhoneNumbers(personId);
            
            existingPerson.PhoneNumbers = Mapper.Map<ICollection<PhoneNumberEntity>>(personData.PhoneNumbers);

            _personRepository.Update(existingPerson);

            Commit();

            return DomainStatusCodes.Success;
        }

        public async Task<DomainStatusCodes> ChangeImageAsync(int personId, UploadImageDTO personImage)
        {
            if (!CheckIfPersonExists(personId, out var existingPerson))
                return DomainStatusCodes.RecordNotFound;

            var imageName = $"{personId}-person-image.png";
            var fileUrl = await _imageService.SaveImageAsync(personImage.Image, imageName);

            existingPerson.Image = imageName;

            _personRepository.Update(existingPerson);

            Commit();

            return DomainStatusCodes.Success;
        }

        public DomainStatusCodes DeleteImage(int personId)
        {
            if (!CheckIfPersonExists(personId, out var existingPerson)) 
                return DomainStatusCodes.RecordNotFound;

            var imageName = $"{personId}-person-image.png";
            _imageService.DeleteImage(imageName);

            existingPerson.Image = null;

            Commit();

            return DomainStatusCodes.Success;
        }

        public DomainStatusCodes DeletePerson(int personId)
        {
            if (!CheckIfPersonExists(personId, out var _))
                return DomainStatusCodes.RecordNotFound;

            var imageName = $"{personId}-person-image.png";
            _imageService.DeleteImage(imageName);
            _personRepository.Remove(personId);

            Commit();

            return DomainStatusCodes.Success;
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using TestProject.Application.Contracts;
using TestProject.Application.DTO.Requests;
using TestProject.Application.DTOs.Filters;
using TestProject.Application.DTOs.Person;
using TestProject.Application.DTOs.RelativePerson;
using TestProject.Application.DTOs.Report;
using TestProject.Application.DTOs.Requests;
using TestProject.Application.DTOs.Search;
using TestProject.Application.Validation;
using TestProject.Domain.Models;

namespace TestProject.API.Controllers
{
    [Route("api/[controller]")]
    [ModelValidation]
    public class PersonController : BaseController
    {
        private readonly IPersonService _personService;

        private readonly IRelatedPersonService _relatedPersonRepository;

        public PersonController(IPersonService personService, IRelatedPersonService relatedPersonRepository) : base()
        {
            _relatedPersonRepository = relatedPersonRepository;
            _personService = personService;
        }

        [HttpGet("{personId}")]
        public IActionResult GetPersonById([RegularExpression(ValidationConfig.IntegerPattern, ErrorMessage = ValidationErrorCodes.NotValidDataType)]int personId)
        {
            var statusCode = _personService.GetFullDataById(personId, out var person);
            return Response(statusCode, person);
        }

        [HttpGet("{personalNumber}/personal-number")]
        public IActionResult GetPersonByPersonalNumber([RegularExpression(ValidationConfig.PersonalNumberPattern, ErrorMessage = ValidationErrorCodes.NotValidDataType)]string personalNumber)
        {
            var statusCode = _personService.GetFullDataByPersonalNumber(personalNumber, out var person);
            return Response(statusCode, person);
        }

        [HttpGet]
        public IActionResult GetPersons([FromQuery] ListReuqestDTO<PersonFilterDTO> requestParams)
        {
            var persons = _personService.GetAll(requestParams);
            return Response(DomainStatusCodes.Success, persons);
        }

        [HttpGet("V2")]
        public IActionResult GetPersonsV2([FromQuery] ListReuqestDTO<PersonFilterDTO> requestParams)
        {
            var persons = _personService.GetAll2(requestParams);
            return Response(DomainStatusCodes.Success, persons);
        }

        [HttpGet("fast-search")]
        public IActionResult GetPersonsViaFastSearch([FromQuery] ListReuqestDTO<FastSearchDTO> requestParams)
        {
            var persons = _personService.GetPersonsViaFastSearch(requestParams);
            return Response(DomainStatusCodes.Success, persons);
        }

        [HttpGet("{personId}/related-persons-amount")]
        public IActionResult GetPersonsRelativesAmountByType(int personId, [FromQuery]RequestReportDTO reportData)
        {
            var statusCode = _relatedPersonRepository.GetPersonsRelativesAmountByType(personId, reportData, out var report);
            return Response(statusCode, report);
        }

        [HttpPost("create")]
        public IActionResult CreatePerson([FromBody]CreatePersonDTO person)
        {
            var statusCode = _personService.CreatePeron(person);
            return Response(statusCode);
        }

        [HttpPost("{userId}/add-relative")]
        public IActionResult CreatePerson(int userId, [FromBody]AddRelativeDTO relative)
        {
            var statusCode = _relatedPersonRepository.AddRelative(userId, relative);
            return Response(statusCode);
        }

        [HttpPut("{personId}/update")]
        public IActionResult UpdatePerson(int personId, [FromBody]CreatePersonDTO person)
        {
            var statusCode = _personService.UpdatePerson(personId, person);
            return Response(statusCode);
        }

        [HttpPut("{personId}/upload-image")]
        public async Task<IActionResult> UploadImageAsync(int personId, [FromForm]UploadImageDTO personImage)
        {
            var statusCode = await _personService.ChangeImageAsync(personId, personImage);
            return Response(statusCode);
        }

        [HttpDelete("{userId}/delete-relative")]
        public IActionResult CreatePerson(int userId, [FromBody]RemoveRelativeDTO relative)
        {
            var statusCode = _relatedPersonRepository.RemoveRelative(userId, relative);
            return Response(statusCode);
        }

        [HttpDelete("{personId}/delete")]
        public IActionResult DeletePerson(int personId)
        {
            var statusCode = _personService.DeletePerson(personId);
            return Response(statusCode);
        }

        [HttpDelete("{personId}/delete-image")]
        public IActionResult DeleteImage(int personId)
        {
            var statusCode = _personService.DeleteImage(personId);
            return Response(statusCode);
        }
    }
}

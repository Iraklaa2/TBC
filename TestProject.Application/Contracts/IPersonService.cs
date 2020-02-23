using System.Threading.Tasks;
using TestProject.Application.DTO.Requests;
using TestProject.Application.DTO.Responses;
using TestProject.Application.DTOs.Filters;
using TestProject.Application.DTOs.Person;
using TestProject.Application.DTOs.Requests;
using TestProject.Application.DTOs.Search;
using TestProject.Domain.Models;

namespace TestProject.Application.Contracts
{
    public interface IPersonService
    {
        ListViewDTO<PersonWithRelativeDTO> GetPersonsViaFastSearch(ListReuqestDTO<FastSearchDTO> requestParams);

        ListViewDTO<PersonWithRelativeDTO> GetAll(ListReuqestDTO<PersonFilterDTO> requestParams);

        DomainStatusCodes GetFullDataById(int personId, out PersonWithRelativeDTO person);

        DomainStatusCodes GetFullDataByPersonalNumber(string personalNumber, out PersonWithRelativeDTO person);

        DomainStatusCodes CreatePeron(CreatePersonDTO personData);

        DomainStatusCodes UpdatePerson(int personId, CreatePersonDTO person);

        DomainStatusCodes DeletePerson(int personId);

        Task<DomainStatusCodes> ChangeImageAsync(int personId, UploadImageDTO personImage);

        DomainStatusCodes DeleteImage(int personId);

        void Dispose();
    }
}
using AutoMapper;
using TestProject.Domain.Contracts;
using TestProject.Domain.Entities;

namespace TestProject.Application.Services
{
    public class BasePersonService : Service
    {
        protected readonly IPersonRepository _personRepository;

        public BasePersonService(IUnitOfWork unitOfWork, IMapper mapper, IPersonRepository personRepository) 
            : base(unitOfWork, mapper) => _personRepository = personRepository;

        protected bool CheckIfPersonExists(int personId, out PersonEntity existingPerson)
        {
            existingPerson = _personRepository.GetById(personId);
            return existingPerson != null;
        }
        
        protected bool CheckIfRelationExists(int personId, out PersonEntity existingPerson)
        {
            existingPerson = _personRepository.GetById(personId);
            return existingPerson != null;
        }

        protected bool CheckIfPersonExistsByPersonalNumber(string personalNumber, out PersonEntity existingPerson)
        {
            existingPerson = _personRepository.GetByPersonalNumber(personalNumber);
            return existingPerson != null;
        }
    }
}

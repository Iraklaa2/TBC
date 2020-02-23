using System.Collections.Generic;
using TestProject.Domain.Entities;
using TestProject.Domain.Models;

namespace TestProject.Domain.Contracts
{
    public interface IPersonRepository : IRepository<PersonEntity>
    {
        IEnumerable<PersonEntity> GetAll(object filters, int page, int limit, out int totalRecords);

        IEnumerable<PersonEntity> GetAll2(PersonFilter filters, int page, int limit, out int totalRecords);
        
        IEnumerable<PersonEntity> SearchByPersonalNumber(string personalNumber, int page, int limit, out int totalRecords);

        IEnumerable<PersonEntity> SearchByFullName(string name, int page, int limit, out int totalRecords);

        PersonEntity GetFullDataById(int id);

        PersonEntity GetFullDataByPersonalNumber(string personalNumber);

        PersonEntity GetByPersonalNumber(string personalNumber);

        int Count(object filters);
    }
}
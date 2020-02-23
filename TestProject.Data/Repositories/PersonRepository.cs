using System.Linq;
using TestProject.Data.Context;
using TestProject.Domain.Contracts;
using TestProject.Domain.Entities;
using System.Collections.Generic;
using TestProject.Domain.Models;
using TestProject.Data.Extensions;

namespace TestProject.Data.Repositories
{
    public class PersonRepository : Repository<PersonEntity>, IPersonRepository
    {
        public PersonRepository(TestProjectDbContext context) : base(context) { }

        public IEnumerable<PersonEntity> GetAll(object filters, int page, int limit, out int totalRecords)
        {
            var query = GetAll()
                .IncludePersonData()
                .Filter(filters);

            totalRecords = query.Count();

            return query
                .Skip(page)
                .Take(limit)
                .ToList();
        }

        public IEnumerable<PersonEntity> SearchByPersonalNumber(string personalNumber, int page, int limit, out int totalRecords)
        {
            var query = DbSet
                .IncludePersonData()
                .Where(p => p.PersonalNumber.Contains(personalNumber));

            totalRecords = query.Count();
            
            return query
                .Skip(page)
                .Take(limit)
                .ToList();
        }

        public IEnumerable<PersonEntity> SearchByFullName(string name, int page, int limit, out int totalRecords)
        {
            var query = DbSet
                .IncludePersonData()
                .Where(p => p.FirstName.ToLower().Contains(name.ToLower()) || p.LastName.ToLower().Contains(name.ToLower()));

            totalRecords = query.Count();

            return query
                .Skip(page)
                .Take(limit)
                .ToList();
        }

        public PersonEntity GetFullDataById(int id)
        {
            return DbSet
                .IncludePersonData()
                .FirstOrDefault(person => person.Id == id);
        }

        public PersonEntity GetFullDataByPersonalNumber(string personalNumber)
        {
            return DbSet
                .IncludePersonData()
                .FirstOrDefault(person => person.PersonalNumber == personalNumber);
        }

        public PersonEntity GetByPersonalNumber(string personalNumber)
        {
            return DbSet
                .FirstOrDefault(person => person.PersonalNumber == personalNumber);
        }

        public IEnumerable<PersonEntity> GetAll2(PersonFilter filters, int page, int limit, out int totalRecords)
        {
            var query = GetAll()
                .IncludePersonData()
                .FilterEntities(filters);

            totalRecords = query.Count();

            return query
                .Skip(page)
                .Take(limit)
                .ToList();
        }

        public int Count(object filters)
        {
            return GetAll()
                .Filter(filters)
                .Count();
        }
    }
}

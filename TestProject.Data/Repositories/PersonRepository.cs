using System.Linq;
using TestProject.Data.Context;
using TestProject.Domain.Contracts;
using TestProject.Domain.Entities;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

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

        public int Count(object filters)
        {
            return GetAll()
                .Filter(filters)
                .Count();
        }
    }

    internal static class PersonRepositoryUtil
    {
        public static IQueryable<PersonEntity> IncludePersonData(this IQueryable<PersonEntity> source)
        {
            return source
                .Include(a => a.City)
                .Include(a => a.PhoneNumbers)
                .Include(a => a.RelatedPersons)
                .Include("RelatedPersons.RelatedPerson")
                .Include("RelatedPersons.RelatedPerson.City")
                .Include("RelatedPersons.RelatedPerson.PhoneNumbers");
        }
    }
}

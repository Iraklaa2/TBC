using Microsoft.EntityFrameworkCore;
using System.Linq;
using TestProject.Domain.Entities;
using TestProject.Domain.Models;

namespace TestProject.Data.Extensions
{
    internal static class PersonUtilsExtension
    {
        public static IQueryable<PersonEntity> FilterEntities(this IQueryable<PersonEntity> source, PersonFilter filters)
        {
            if (filters.FirstName != null)
                source = source.Where(p => p.FirstName.ToLower().Contains(filters.FirstName));

            if (filters.LastName != null)
                source = source.Where(p => p.LastName.ToLower().Contains(filters.LastName));

            if (filters.PersonalNumber != null)
                source = source.Where(p => p.PersonalNumber.Contains(filters.PersonalNumber));

            if (filters.DateOfBirth != null)
                source = source.Where(p => p.DateOfBirth == filters.DateOfBirth);

            if (filters.City != null)
                source = source.Where(p => p.City.Name.ToLower().Contains(filters.City));

            if (filters.Gender != null)
                source = source.Where(p => p.Gender == filters.Gender);

            if (filters.PhoneNumber != null)
                source = source.Where(p => p.PhoneNumbers.Any(ph => ph.Number.Contains(filters.PhoneNumber)));

            if (filters.PhoneNumberType != null)
                source = source.Where(p => p.PhoneNumbers.Any(ph => ph.Type == filters.PhoneNumberType));

            return source;
        }

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

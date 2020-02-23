using System.Collections.Generic;
using System.Linq;
using TestProject.Data.Context;
using TestProject.Domain.Contracts;
using TestProject.Domain.Entities;

namespace TestProject.Data.Repositories
{
    public class PhoneNumberRepository : Repository<PhoneNumberEntity>, IPhoneNumberRepository
    {
        public PhoneNumberRepository(TestProjectDbContext context) : base(context) { }

        public IEnumerable<PhoneNumberEntity> GetPersonsPhoneNumbers(int personId)
        {
            return GetAll()
                .Where(p => p.PersonId == personId);
        }

        public void RemovePersonsPhoneNumbers(int personId)
        {
            DbSet.RemoveRange(DbSet.Where(p => p.PersonId == personId));
        }
    }
}

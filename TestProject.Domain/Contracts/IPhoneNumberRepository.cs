using System.Collections.Generic;
using TestProject.Domain.Entities;

namespace TestProject.Domain.Contracts
{
    public interface IPhoneNumberRepository : IRepository<PhoneNumberEntity>
    {
        IEnumerable<PhoneNumberEntity> GetPersonsPhoneNumbers(int personId);

        void RemovePersonsPhoneNumbers(int personId);
    }
}

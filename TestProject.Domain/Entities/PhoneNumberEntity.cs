using TestProject.Domain.Models;

namespace TestProject.Domain.Entities
{
    public class PhoneNumberEntity : Entity
    {
        public PhoneNumberType Type { get; set; }

        public string Number { get; set; }

        public int PersonId { get; set; }

        public PersonEntity Person { get; set; }
    }
}

using System;

namespace TestProject.Domain.Models
{
    public class PersonFilter
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PersonalNumber { get; set; }

        public GenderType? Gender { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string City { get; set; }

        public string PhoneNumber { get; set; }

        public PhoneNumberType? PhoneNumberType { get; set; }
    }
}

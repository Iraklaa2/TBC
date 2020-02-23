using System;
using System.Collections.Generic;
using TestProject.Application.DTOs.PhoneNumber;

namespace TestProject.Application.DTOs.Person
{
    public class PersonDTO
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PersonalNumber { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Gender { get; set; }

        public string City { get; set; }

        public ICollection<PhoneNumberDTO> PhoneNumbers { get; set; }
    }
}

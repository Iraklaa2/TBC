using System;
using System.Collections.Generic;
using TestProject.Domain.Models;

namespace TestProject.Domain.Entities
{
    public class PersonEntity : Entity
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public GenderType Gender { get; set; }

        public string PersonalNumber { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Image { get; set; }

        public int CityId { get; set; }

        public CityEntity City { get; set; }

        public ICollection<PhoneNumberEntity> PhoneNumbers { get; set; }

        public ICollection<RelatedPersonEntity> RelatedPersons { get; set; }
    }
}

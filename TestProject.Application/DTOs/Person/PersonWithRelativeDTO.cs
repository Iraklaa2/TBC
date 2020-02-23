using System.Collections.Generic;
using TestProject.Application.DTOs.RelativePerson;

namespace TestProject.Application.DTOs.Person
{
    public class PersonWithRelativeDTO : PersonDTO
    {
        public IEnumerable<RelatedRelationDTO> RelatedPersons { get; set; }
    }
}

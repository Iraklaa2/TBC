using TestProject.Application.DTOs.Person;

namespace TestProject.Application.DTOs.RelativePerson
{
    public class RelatedRelationDTO
    {
        public string RelationType { get; set; }

        public PersonDTO Person { get; set; }
    }
}

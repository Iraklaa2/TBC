using TestProject.Domain.Models;

namespace TestProject.Domain.Entities
{
    public class RelatedPersonEntity
    {
        public RelatedPersonsType RelationType { get; set; }

        public int PersonId { get; set; }
        
        public PersonEntity Person { get; set; }

        public int RelatedPersonId { get; set; }

        public PersonEntity RelatedPerson { get; set; }
    }
}

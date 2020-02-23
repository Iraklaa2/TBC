using System.Collections.Generic;

namespace TestProject.Domain.Entities
{
    public class CityEntity : Entity
    {
        public string Name { get; set; }

        public IEnumerable<PersonEntity> Persons { get; set; }
    }
}

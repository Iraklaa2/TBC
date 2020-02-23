namespace TestProject.Domain.Entities
{
    public class CityEntity : Entity
    {
        public string Name { get; set; }

        public PersonEntity Person { get; set; }
    }
}

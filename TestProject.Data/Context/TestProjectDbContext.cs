using Microsoft.EntityFrameworkCore;
using TestProject.Data.Mappings;
using TestProject.Domain.Entities;

namespace TestProject.Data.Context
{
    public class TestProjectDbContext : DbContext
    {
        public TestProjectDbContext(DbContextOptions<TestProjectDbContext> options) : base(options) { }

        public DbSet<PersonEntity> Persons { get; set; }

        public DbSet<RelatedPersonEntity> RelatedPersons { get; set; }

        public DbSet<CityEntity> Cities { get; set; }

        public DbSet<PhoneNumberEntity> PhoneNumbers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CityEntityMap());
            modelBuilder.ApplyConfiguration(new PersonEntityMap());
            modelBuilder.ApplyConfiguration(new RelatedPersonEntityMap());
            modelBuilder.ApplyConfiguration(new PhoneNumberEntityMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}

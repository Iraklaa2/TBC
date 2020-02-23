using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using TestProject.Data.Mappings;
using TestProject.Domain.Entities;
using TestProject.Logger;

namespace TestProject.Data.Context
{
    public class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }

        public IList<StudentCourse> StudentCourses { get; set; }
    }

    public class Course
    {
        public int CourseId { get; set; }
        public string CourseName { get; set; }
        public string Description { get; set; }

        public IList<StudentCourse> StudentCourses { get; set; }
    }

    public class StudentCourse
    {
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public int CourseId { get; set; }
        public Course Course { get; set; }
    }


    public class TestProjectDbContext : DbContext
    {
        public TestProjectDbContext(DbContextOptions<TestProjectDbContext> options) : base(options) { }

        public DbSet<PersonEntity> Persons { get; set; }

        public DbSet<RelatedPersonEntity> RelatedPersons { get; set; }

        public DbSet<CityEntity> Cities { get; set; }

        public DbSet<PhoneNumberEntity> PhoneNumbers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLoggerFactory(ApplicationLogging.LoggerFactory);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.UseLoggerFactory(ApplicationLogging.LoggerFactory);

            // TODO ES IMENA MUSHAA <3 
            //modelBuilder.Entity<RelatedPersonEntity>()
            //    .Property(a=>a.RelatedPersonId);

            //modelBuilder.Entity<RelatedPersonEntity>()
            //    .Property(a => a.PersonId);

            //modelBuilder.Entity<RelatedPersonEntity>()
            //     .HasKey("PersonId", "RelatedPersonId");

            //modelBuilder.Entity<RelatedPersonEntity>().HasOne(olol => olol.RelatedPerson)
            //    .WithMany(col => col.RelatedPersons)
            //    .OnDelete(DeleteBehavior.Restrict);



            modelBuilder.ApplyConfiguration(new CityEntityMap());
            modelBuilder.ApplyConfiguration(new PersonEntityMap());
            modelBuilder.ApplyConfiguration(new RelatedPersonEntityMap());
            modelBuilder.ApplyConfiguration(new PhoneNumberEntityMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}

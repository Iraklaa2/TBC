﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestProject.Data.Mappings.SeedData;
using TestProject.Domain.Entities;

namespace TestProject.Data.Mappings
{
    public class PersonEntityMap : IEntityTypeConfiguration<PersonEntity>
    {
        public void Configure(EntityTypeBuilder<PersonEntity> builder)
        {
            builder.Property(c => c.DateOfBirth)
                .HasColumnType("date")
                .IsRequired();

            builder.Property(c => c.FirstName)
                .HasColumnType("varchar(50)")
                .HasMaxLength(50)
                .IsRequired();

            builder.Property(c => c.LastName)
                .HasColumnType("varchar(50)")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(c => c.PersonalNumber)
                .HasColumnType("char(11)")
                .IsFixedLength(true)
                .IsRequired();

            builder
                .HasIndex(u => u.PersonalNumber)
                .IsUnique();

            builder.HasIndex(a => a.FirstName);

            builder.HasIndex(a => a.LastName);

            builder.HasOne(a => a.City).WithOne(a => a.Person).OnDelete(DeleteBehavior.Restrict);
            // TODO: cascades

            // builder.HasData(PersonsSeedData.Data);
        }
    }
}

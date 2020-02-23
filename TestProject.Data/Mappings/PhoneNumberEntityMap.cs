using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestProject.Data.Mappings.SeedData;
using TestProject.Domain.Entities;

namespace TestProject.Data.Mappings
{
    public class PhoneNumberEntityMap : IEntityTypeConfiguration<PhoneNumberEntity>
    {
        public void Configure(EntityTypeBuilder<PhoneNumberEntity> builder)
        {
            builder.Property(c => c.Number)
                .HasColumnType("varchar(50)")
                .HasMaxLength(50)
                .IsRequired();

           builder.HasData(PhoneNumbersSeedData.Data);
        }
    }
}

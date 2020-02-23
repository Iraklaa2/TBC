using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestProject.Data.Mappings.SeedData;
using TestProject.Domain.Entities;

namespace TestProject.Data.Mappings
{
    public class CityEntityMap : IEntityTypeConfiguration<CityEntity>
    {
        public void Configure(EntityTypeBuilder<CityEntity> builder)
        {
            builder.Property(c => c.Name)
                .HasColumnType("varchar(20)")
                .HasMaxLength(20)
                .IsRequired();

            builder.HasData(CitiesSeedData.Data);
        }
    }
}

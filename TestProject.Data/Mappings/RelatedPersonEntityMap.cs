using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using TestProject.Domain.Entities;

namespace TestProject.Data.Mappings
{
    public class RelatedPersonEntityMap : IEntityTypeConfiguration<RelatedPersonEntity>
    {
        public void Configure(EntityTypeBuilder<RelatedPersonEntity> builder)
        {
            builder
                .HasKey(e => new { e.RelatedPersonId, e.PersonId });

            builder
                .Property(a => a.RelatedPersonId);

            builder
                .Property(a => a.PersonId);

            builder.HasOne(olol => olol.Person)
                .WithMany(col => col.RelatedPersons)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

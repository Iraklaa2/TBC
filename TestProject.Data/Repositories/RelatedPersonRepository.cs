using System.Linq;
using TestProject.Data.Context;
using TestProject.Domain.Contracts;
using TestProject.Domain.Entities;
using TestProject.Domain.Models;

namespace TestProject.Data.Repositories
{
    public class RelatedPersonRepository : Repository<RelatedPersonEntity>, IRelatedPersonRepository
    {
        public RelatedPersonRepository(TestProjectDbContext context) : base(context) { }

        public RelatedPersonEntity GetRelation(int personId, int relatedPersonId)
        {
            return DbSet.FirstOrDefault(r => r.PersonId == personId && r.RelatedPersonId == relatedPersonId);
        }

        public void Remove(int personId, int relativePersonId)
        {
            // TODO: We Already have relation entity in service, pass it as argument, to be avoid re fetch entity from DB
            var relation = DbSet.FirstOrDefault(r => r.PersonId == personId && r.RelatedPersonId == relativePersonId);
            DbSet.Remove(relation);
        }

        public int PersonsRelativesAmountByType(int personId, RelatedPersonsType relatedPersonsType)
        {
            return DbSet.Count(r => r.PersonId == personId && r.RelationType == relatedPersonsType);
        }
    }
}

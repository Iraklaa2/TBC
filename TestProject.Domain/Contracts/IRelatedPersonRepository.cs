using System.Collections.Generic;
using TestProject.Domain.Entities;
using TestProject.Domain.Models;

namespace TestProject.Domain.Contracts
{
    public interface IRelatedPersonRepository : IRepository<RelatedPersonEntity>
    {
        RelatedPersonEntity GetRelation(int personId, int relatedPersonId);

        void Remove(int personId, int relativePersonId);

        int PersonsRelativesAmountByType(int personId, RelatedPersonsType relatedPersonsType);

        IEnumerable<RelatedPersonEntity> GetPersonsAllRelations(int personId);

        void RemovePersonsAllRelations(IEnumerable<RelatedPersonEntity> relations);
    }
}
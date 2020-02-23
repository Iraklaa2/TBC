using System.Collections.Generic;
using TestProject.Domain.Entities;

namespace TestProject.Domain.Contracts
{
    public interface ICityRepository : IRepository<CityEntity>
    {
        IEnumerable<CityEntity> GetAll(object filters, int page, int limit, out int totalRecords);
    }
}

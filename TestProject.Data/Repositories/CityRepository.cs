using System.Collections.Generic;
using System.Linq;
using TestProject.Data.Context;
using TestProject.Domain.Contracts;
using TestProject.Domain.Entities;

namespace TestProject.Data.Repositories
{
    public class CityRepository : Repository<CityEntity>, ICityRepository
    {
        public CityRepository(TestProjectDbContext context) : base(context) { }

        public IEnumerable<CityEntity> GetAll(object filters, int page, int limit, out int totalRecords)
        {
            var query = GetAll()
                .Filter(filters);

            totalRecords = query.Count();

            return query
                .Skip(page)
                .Take(limit)
                .ToList();
        }
    }
}

using TestProject.Data.Context;
using TestProject.Domain.Contracts;

namespace TestProject.Data.UoW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly TestProjectDbContext _context;

        public UnitOfWork(TestProjectDbContext context)
        {
            _context = context;
        }

        public bool Commit()
        {
            return _context.SaveChanges() > 0;
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

using System;
using System.Linq;

namespace TestProject.Domain.Contracts
{
    public interface IRepository<TEntity> : IDisposable where TEntity : class
    {
        void Add(TEntity entity);
        
        TEntity GetById(int id);
        
        IQueryable<TEntity> GetAll();
        
        void Update(TEntity entity);

        int Count();

        void Remove(int id);
        
        int SaveChanges();
    }
}

using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using TestProject.Data.Context;
using TestProject.Domain.Contracts;

namespace TestProject.Data.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly TestProjectDbContext Cntext;

        protected readonly DbSet<TEntity> DbSet;

        public Repository(TestProjectDbContext context)
        {
            Cntext = context;
            DbSet = Cntext.Set<TEntity>();
        }

        public virtual void Add(TEntity entity)
        {
            DbSet.Add(entity);
        }

        public virtual TEntity GetById(int id)
        {
            return DbSet.Find(id);
        }

        public virtual IQueryable<TEntity> GetAll()
        {
            return DbSet;
        }

        public virtual void Update(TEntity entity)
        {
            Cntext.Entry(entity).State = EntityState.Modified;
            DbSet.Update(entity);
        }

        public virtual void Remove(int id)
        {
            // TODO: We Already have relation in service, pass it as argument, to be avoid re fetch entiry from DB
            DbSet.Remove(DbSet.Find(id));
        }

        public int SaveChanges()
        {
            return Cntext.SaveChanges();
        }

        public int Count()
        {
            return DbSet.Count();
        }

        public void Dispose()
        {
            Cntext.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
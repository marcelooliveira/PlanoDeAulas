using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using UnitOfWork.Entities;

namespace UnitOfWork.DAL
{
    public class GenericRepository<TEntity> where TEntity : class
    {
        internal EscolaContext context;
        internal DbSet<TEntity> dbSet;

        public GenericRepository(EscolaContext context)
        {
            this.context = context;
            this.dbSet = context.Set<TEntity>();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return dbSet.ToList();
        }
        public TEntity GetById(int id)
        {
            return dbSet.Find(id);
        }
        public TEntity Find(Expression<Func<TEntity, bool>> filter)
        {
            return dbSet.Where(filter).SingleOrDefault();
        }
        public TEntity Insert(TEntity entity)
        {
            return dbSet.Add(entity);
        }
        public void Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }
        public void Delete(int id)
        {
            TEntity entity = dbSet.Find(id);
            dbSet.Remove(entity);
        }
        public void Save()
        {
            context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}

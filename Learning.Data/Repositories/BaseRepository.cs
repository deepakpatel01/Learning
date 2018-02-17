using System;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;
using Learning.BusinessLogic.Infrastructure.Interfaces;

namespace Learning.Data.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : class
    {
        private LearningContext _ctx;
        internal DbSet<T> dbSet;
        public BaseRepository(LearningContext ctx)
        {
            _ctx = ctx;
            this.dbSet = _ctx.Set<T>();
        }

        public void Add(T newEntity)
        {
            this.dbSet.Add(newEntity);
        }

        public T FindFirst(Expression<Func<T, bool>> predicate)
        {
            return this.dbSet.Where(predicate).FirstOrDefault();
        }

        public T Get(int id)
        {
            return this.dbSet.Find(id);
        }

        public IQueryable<T> GetAll(Func<T, bool> predicate = null)
        {
            return this.dbSet;
        }

        public void Remove(T entity)
        {
            this.dbSet.Remove(entity);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;

namespace ONLINESHOP.Data.Infrastructure
{
    public class RepositoryBase<T> : IRepository<T> where T : class
    {
        private ONLINESHOPDBCONTEXT dataContext;
        private readonly IDbSet<T> dbSet;

        protected IDbFactory DbFactory
        {
            get;
            private set;
        }

        protected ONLINESHOPDBCONTEXT DbContext
        {
            get
            {
                return dataContext ?? (dataContext = DbFactory.Init());
            }
        }

        protected RepositoryBase(IDbFactory dbFactory)
        {
            DbFactory = dbFactory;
            dbSet = DbContext.Set<T>();
        }

        public virtual T Add(T entity)
        {
            return dbSet.Add(entity);
        }

        public virtual bool CheckContains(Expression<Func<T, bool>> predicate)
        {
            return dbSet.Count<T>(predicate) > 0;
        }

        public virtual int Count(Expression<Func<T, bool>> where)
        {
            return dbSet.Count(where);
        }

        public virtual T Delete(int id)
        {
            var entity = dbSet.Find(id);
            return dbSet.Remove(entity);
        }

        public virtual T Delete(T entity)
        {
            return dbSet.Remove(entity);
        }

        public virtual void DeleteMulti(Expression<Func<T, bool>> where)
        {
            IEnumerable<T> objects = dbSet.Where<T>(where).AsQueryable();
            foreach (T item in objects)
                dbSet.Remove(item);
        }

        public virtual IEnumerable<T> GetAll(string[] includes = null)
        {
            if (includes != null && includes.Count() > 0)
            {
                var query = dbSet.Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                return query.AsQueryable<T>();
            }
            return dbSet.AsQueryable<T>();
        }

        public virtual IEnumerable<T> GetMulti(Expression<Func<T, bool>> pridicate, string[] includes = null)
        {
            return GetAll(includes).AsQueryable<T>().Where(pridicate);
        }

        public virtual IEnumerable<T> GetMultiPaging(Expression<Func<T, bool>> fillter, out int total, int page = 1, int pageSize = 5, string[] includes = null)
        {
            int skipCount = (page - 1) * pageSize;
            IQueryable<T> _resetSet;

            if (includes != null && includes.Count() > 0)
            {
                var query = dbSet.Include(includes.First());
                foreach (var include in includes.Skip(1))
                    query = query.Include(include);
                _resetSet = fillter != null ? query.Where<T>(fillter).AsQueryable<T>() : query.AsQueryable<T>();
            }
            else
            {
                _resetSet = fillter != null ? dbSet.Where<T>(fillter).AsQueryable<T>() : dbSet.AsQueryable<T>();
            }
            total = _resetSet.Count();
            _resetSet = skipCount == 0 ? _resetSet.Take(pageSize) : _resetSet.Skip(skipCount).Take(pageSize);

            return _resetSet.AsQueryable<T>();
        }

        public virtual T SingleByCondition(Expression<Func<T, bool>> where, string[] includes = null)
        {
            return GetAll(includes).AsQueryable<T>().FirstOrDefault(where);
        }

        public virtual T SingleById(int id)
        {
            return dbSet.Find(id);
        }

        public virtual void Update(T entity)
        {
            dbSet.Attach(entity);
            dataContext.Entry(entity).State = EntityState.Modified;
        }
    }
}
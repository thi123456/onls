using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ONLINESHOP.Data.Infrastructure
{
    public interface IRepository<T> where T : class
    {
        T Add(T entity);

        T Delete(T entity);

        T Delete(int id);

        void DeleteV(int id);

        void Update(T entity);

        void DeleteMulti(Expression<Func<T, bool>> where);

       

        T SingleById(int id);

        T SingleByCondition(Expression<Func<T, bool>> Where, string[] includes = null);

        IEnumerable<T> GetAll(string[] includes = null);

        IEnumerable<T> GetMulti(Expression<Func<T, bool>> pridicate, string[] includes = null);

        IQueryable<T> GetMultiPaging(Expression<Func<T, bool>> fillter, out int total, int page = 1, int pageSize = 5, string[] includes = null);

        

        int Count(Expression<Func<T, bool>> where);

        bool CheckContains(Expression<Func<T, bool>> predicate);
    }
}
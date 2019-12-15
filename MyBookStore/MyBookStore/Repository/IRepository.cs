using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MyBookStore.Repository
{
    public interface IRepository<T>
    {
        T GetById(Guid id);
        IQueryable<T> GetAll();
        IEnumerable<T> Get(Expression<Func<T, bool>> filter = null,
               Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "");
        void Update(T entity);
        void Create(T entity);
        void Delete(T entity);

    }
}

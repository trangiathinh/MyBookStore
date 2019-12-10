using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyBookStore.Repository
{
    public interface IRepository<T>
    {
        T GetById(Guid id);
        IQueryable<T> GetAll();
        void Update(T entity);
        void Create(T entity);
        void Delete(T entity);
    }
}

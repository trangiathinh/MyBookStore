using Microsoft.EntityFrameworkCore;
using MyBookStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace MyBookStore.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private MyBookStoreContext context;
        private DbSet<T> dbset;
        public Repository(MyBookStoreContext context)
        {
            this.context = context;
            dbset = context.Set<T>();
        }
        public void Create(T entity)
        {
            context.Entry(entity).State = EntityState.Added;
        }

        public void Delete(T entity)
        {
            context.Entry(entity).State = EntityState.Deleted;
        }

        public IQueryable<T> GetAll()
        {
            return dbset;
        }
        public virtual IEnumerable<T> Get(Expression<Func<T, bool>> filter = null,
               Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            //assign quey get all entities
            IQueryable<T> query = dbset;
            //check if filter not equal null
            if (filter != null)
            {
                query = query.Where(filter);
            }
            List<string> listProperties = includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            foreach (var includeProperty in listProperties)
            {
                query = query.Include(includeProperty);
            }

            if (orderBy != null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
        }
        public T GetById(Guid id)
        {
            return dbset.Find(id);
        }

        public void Update(T entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }
    }
}

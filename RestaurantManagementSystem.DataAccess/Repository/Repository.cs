using Microsoft.EntityFrameworkCore;
using RestaurantManagementSystem.DataAccess.Data;
using RestaurantManagementSystem.DataAccess.Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly ApplicationDBContext _db;
        internal DbSet<T> dbSet;
        public Repository(ApplicationDBContext db)
        {
            _db = db;
            //_db.MenuItem.Include(u => u.FoodType).Include(u => u.Category);
            //_db.MenuItem.OrderBy(x => x.Name);
            dbSet = db.Set<T>();
        }

        public void Add(T entity)
        {
            dbSet.Add(entity);
        }

        public IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null, Func<IQueryable<T>, IOrderedQueryable<T>>? orderby = null, string? includingProperties = null)
        {
            IQueryable<T> query = dbSet;
            if(includingProperties != null)
            {
                foreach(var includingProperty in includingProperties.Split(
                    new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query=query.Include(includingProperty);
                }
            }
            if(orderby != null)
            {
                return orderby(query).ToList();
            }
            return query.ToList();
        } 
        public T GetFirstOrDefault(Expression<Func<T, bool>>? filter = null,string includingProperties = null)
        {
            IQueryable<T> query = dbSet;
            if (filter != null)
            {
                query = query.Where(filter); 
            }
            if (includingProperties != null)
            {
                foreach (var includingProperty in includingProperties.Split(
                    new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(includingProperty);
                }
            }

            return query.FirstOrDefault();
        }

        public void Remove(T entity)
        {
            dbSet.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            dbSet.RemoveRange(entities);
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantManagementSystem.DataAccess.Repository.IRepository
{
   public interface IRepository<T> where T : class
    {
        void Add(T entity);
        void Remove(T entity);
        void RemoveRange(IEnumerable<T> entities);
        IEnumerable<T> GetAll(Expression<Func<T, bool>>? filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>>? orderby= null,
            string? includingProperties = null);
        T GetFirstOrDefault(Expression<Func<T, bool>>? filter = null,string? includingProperties = null);
    }
}

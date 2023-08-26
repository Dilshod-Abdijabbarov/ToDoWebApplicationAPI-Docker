using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ToDoWebApplication.Data.IRepositories
{
    public interface IGenericRepositoryAsync<T> where T : class
    {
        public ValueTask<T> GetAsync(Expression<Func<T, bool>> expression, 
                            Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null);
        public IQueryable<T> GetAllAsync(Expression<Func<T, bool>> expression,
                             Func<IQueryable<T>, IIncludableQueryable<T, object>>? include = null, bool isTracking = true);
        public ValueTask<bool> DeleteAsync(Expression<Func<T, bool>> expression);
        public T Update(T entity);
        public ValueTask<T> CreateAsync(T entity);
        public ValueTask SaveChangesAsync();
    }
}

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Contracts
{
    public interface IRepository<T> where T:class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetAsync(int id);
        Task<T> FirstOrDefaultAsync(Expression<Func<T,bool>> predicate);
        Task AddAsync(T entity);
        void Remove(T entity);
    }
}

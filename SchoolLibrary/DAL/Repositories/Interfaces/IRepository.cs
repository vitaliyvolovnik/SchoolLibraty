using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        Task<T?> CreateAsync(T entity);
        Task<T?> UpdateAsync(T entity,int entityId);
        Task DeleteAsync(Expression<Func<T, bool>> predicate);

        Task<T?> FindFirstAsync(Expression<Func<T, bool>> predicate);
        Task<ObservableCollection<T>> FindByConditionalAsync(Expression<Func<T, bool>> predicate);

        Task<ObservableCollection<T>> GetAllAsync();
    }
}

using DAL.Context;
using DAL.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class BaseRepository<T> :IRepository<T>  where T : class
    {
        private readonly SchoolLibraryContext _context;

        public BaseRepository(SchoolLibraryContext context) 
        {
            _context = context;
        }

        private DbSet<T> enitities;
        protected DbSet<T> Entities => enitities ??= _context.Set<T>();

        public virtual async Task<T?> CreateAsync(T entity)
        {
            try
            {
                T createdEntity = Entities.Add(entity).Entity;
                await SaveChangesAsync();
                return createdEntity;
            }
            catch
            {
                return null;
            }
        }

        public virtual async Task<T?> UpdateAsync(T entity,int entityId)
        {
            throw new NotImplementedException();
        }

        public virtual async Task DeleteAsync(Expression<Func<T, bool>> predicate)
        {

            var entities = await Entities.Where(predicate).ToListAsync();
            Entities.RemoveRange(entities);

            await SaveChangesAsync();
        }

        public virtual async Task<T?> FindFirstAsync(Expression<Func<T, bool>> predicate)
        {
            return await Entities.FirstOrDefaultAsync(predicate);
        }

        public virtual async Task<ObservableCollection<T>> FindByConditionalAsync(Expression<Func<T, bool>> predicate)
        {
            var entities = await _context.Set<T>().Where(predicate).ToListAsync();
            return new ObservableCollection<T>(entities);
        }

        public virtual async Task<ObservableCollection<T>> GetAllAsync()
        {
            var entities = await _context.Set<T>().ToListAsync();
            return new ObservableCollection<T>(entities);
        }
        
        public virtual async Task SaveChangesAsync()
        {
           await _context.SaveChangesAsync();
        }
    }
}

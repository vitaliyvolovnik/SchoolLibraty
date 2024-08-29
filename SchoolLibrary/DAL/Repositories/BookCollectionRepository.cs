using DAL.Context;
using Domain.Models;
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
    public class BookCollectionRepository : BaseRepository<BookCollection>
    {
        public BookCollectionRepository(SchoolLibraryContext context) : base(context)
        {
        }

        public override async Task<ObservableCollection<BookCollection>> FindByConditionalAsync(Expression<Func<BookCollection, bool>> predicate)
        {
            return new ObservableCollection<BookCollection>(await Entities
                .Include(collection => collection.Books).ThenInclude(book => book.Authors)
                .Where(predicate)
                .ToListAsync());
        }


        public override async Task<BookCollection?> FindFirstAsync(Expression<Func<BookCollection, bool>> predicate)
        {
            return await Entities
                .Include(collection => collection.Books).ThenInclude(book => book.Authors)
                .FirstOrDefaultAsync(predicate);
        }

        public override async Task<ObservableCollection<BookCollection>> GetAllAsync()
        {
            return new ObservableCollection<BookCollection>(await Entities
                .Include(collection => collection.Books).ThenInclude(book => book.Authors)
                .ToListAsync());
        }




        /*public override async Task<BookCollection?> UpdateAsync(BookCollection entity)
        {
            var collection =await this.FindFirstAsync(collection => collection.Id == entity.Id);

            if (collection == null)
                return null;

            if(!string.IsNullOrWhiteSpace(entity.Name))
                collection.Name = entity.Name;
            if(entity.Books != null)
                collection.Books = entity.Books;

            return collection;
        }*/
    }
}

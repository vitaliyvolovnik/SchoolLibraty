using DAL.Context;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Migrations.Operations;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class BookRepository : BaseRepository<Book>
    {
        public BookRepository(SchoolLibraryContext context) : base(context)
        {
        }

        public override async Task<ObservableCollection<Book>> FindByConditionalAsync(Expression<Func<Book, bool>> predicate)
        {
            return new ObservableCollection<Book>(await Entities
                .Include(book => book.Authors)
                .Where(predicate)
                .ToListAsync());
        }

        public override async Task<ObservableCollection<Book>> GetAllAsync()
        {
            return new ObservableCollection<Book>(await Entities
                .Include(book => book.Authors)
                .ToListAsync());
        }

        public override async Task<Book?> FindFirstAsync(Expression<Func<Book, bool>> predicate)
        {
            return await Entities.FirstOrDefaultAsync(predicate);
        }

        public async Task<Book?> AddCount(int bookId, int count)
        {
            var book = await FindFirstAsync(book => book.Id == bookId);

            if (book == null) return null;

            book.Count += count;
            

            await SaveChangesAsync();
            return book;

        }
    }
}

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
    public class AuthorRepository : BaseRepository<Author>
    {
        public AuthorRepository(SchoolLibraryContext context) : base(context)
        {
        }

        public override async Task<Author?> FindFirstAsync(Expression<Func<Author, bool>> predicate)
        {
            return await Entities
                .Include(author => author.Books)
                .FirstOrDefaultAsync();
        }

        public override async Task<ObservableCollection<Author>> FindByConditionalAsync(Expression<Func<Author, bool>> predicate)
        {
            return new ObservableCollection<Author>(await Entities
                .Include(author => author.Books)
                .Where(predicate)
                .ToListAsync());
        }

        public override async Task<ObservableCollection<Author>> GetAllAsync()
        {
            return new ObservableCollection<Author>(await Entities
                .Include(author => author.Books)
                .ToListAsync());
        }
    }
}

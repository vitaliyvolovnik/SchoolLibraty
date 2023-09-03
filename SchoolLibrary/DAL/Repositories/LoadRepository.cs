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
    public class LoadRepository : BaseRepository<Load>
    {
        public LoadRepository(SchoolLibraryContext context) : base(context)
        {
        }

        public override async Task<ObservableCollection<Load>> FindByConditionalAsync(Expression<Func<Load, bool>> predicate)
        {
            return new ObservableCollection<Load>(await Entities
                .Include(load => load.Student).ThenInclude(student => student.Person)
                .Include(load => load.Books).ThenInclude(book => book.Authors).ThenInclude(author => author.Person)
                .Where(predicate)
                .ToListAsync());
        }

        public override async Task<ObservableCollection<Load>> GetAllAsync()
        {
            return new ObservableCollection<Load>(await Entities
                .Include(load => load.Student).ThenInclude(student => student.Person)
                .Include(load => load.Books).ThenInclude(book => book.Authors).ThenInclude(author => author.Person)
                .ToListAsync());
        }

        public override async Task<Load?> FindFirstAsync(Expression<Func<Load, bool>> predicate)
        {
            return await Entities
                .Include(load => load.Student).ThenInclude(student => student.Person)
                .Include(load => load.Books).ThenInclude(book => book.Authors).ThenInclude(author => author.Person)
                .FirstOrDefaultAsync();
        }



    }
}

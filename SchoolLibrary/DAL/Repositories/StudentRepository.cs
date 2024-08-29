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
    public class StudentRepository : BaseRepository<Student>
    {
        public StudentRepository(SchoolLibraryContext context) : base(context)
        {
        }

        public override async Task<ObservableCollection<Student>> GetAllAsync()
        {
            return new ObservableCollection<Student>(await Entities
                .Include(student => student.Person)
                .ToListAsync());
        }

        public override async Task<ObservableCollection<Student>> FindByConditionalAsync(Expression<Func<Student, bool>> predicate)
        {
            return new ObservableCollection<Student>(await Entities
                .Include(student => student.Person)
                .Where(predicate)
                .ToListAsync());
        }

        public override async Task<Student?> FindFirstAsync(Expression<Func<Student, bool>> predicate)
        {
            return await Entities
                .Include(student => student.Person)
                .FirstOrDefaultAsync(predicate);
        }

        public async Task UpClass()
        {
            var students = await Entities.Where(student =>student.Class<=11).ToListAsync();
            students.ForEach(student => { student.Class++; });

            await SaveChangesAsync();
        }
    }
}
 
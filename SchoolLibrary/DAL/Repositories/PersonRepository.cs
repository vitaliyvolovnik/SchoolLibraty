using DAL.Context;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class PersonRepository : BaseRepository<Person>
    {
        public PersonRepository(SchoolLibraryContext context) : base(context)
        {
        }
    }
}

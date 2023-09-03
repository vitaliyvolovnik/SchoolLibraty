using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Author
    {
        public int Id { get; set; }

        public Person? Person { get; set; }
        public int? PersonId { get; set; }

        public ObservableCollection<Book> Books { get; set; } = new();

    }
}

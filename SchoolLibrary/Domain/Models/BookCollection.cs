using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class BookCollection
    {
        public int Id { get; set; }

        public string? Name{ get; set; }

        public ObservableCollection<Book> Books { get; set; } = new();


    }
}

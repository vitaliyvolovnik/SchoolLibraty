using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Book
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Year { get; set; }
        public ObservableCollection<Author> Authors { get; set; } = new();

        public ObservableCollection<BookCollection> Collections { get; set; } = new();

    }
}

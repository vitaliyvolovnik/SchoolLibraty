using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class Load
    {
        public int Id { get; set; }

        public ObservableCollection<Book> Books { get; set; } = new();

        public DateTime IssueDate { get; set; }
        public DateTime ReturnDate { get; set; }


        public Student? Student { get; set; }
        public int? StudentId { get; set; }

    }
}

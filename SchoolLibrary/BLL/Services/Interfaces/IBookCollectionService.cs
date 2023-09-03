using Domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IBookCollectionService
    {

        Task<BookCollection?> AddAsync(BookCollection collection);

        Task<BookCollection?> GetAsync(int id);

        Task<ObservableCollection<BookCollection>> GetAllAsync();

    }
}

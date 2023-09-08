using Domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface ILoadSerivce
    {
        Task<Load?> AddAsync(Load load);

        Task RemoveAsync(int id);
        Task<Load?> GetAsync(int id);

        Task<ObservableCollection<Load>> GetAllAsync();
        Task<ObservableCollection<Load>> GetByStudent(int studentId);
        Task<ObservableCollection<Load>> GetByBookAsync(int bookId);
        Task<ObservableCollection<Load>> GetOverdue();


    }
}

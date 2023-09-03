using BLL.Services.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    internal class LoadService : ILoadSerivce
    {
        public Task<Load?> AddAsync(Load load)
        {
            throw new NotImplementedException();
        }

        public Task<ObservableCollection<Load>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Load?> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ObservableCollection<Load>> GetByBookAsync(int bookId)
        {
            throw new NotImplementedException();
        }

        public Task<ObservableCollection<Load>> GetByStudent(int studentId)
        {
            throw new NotImplementedException();
        }

        public Task<ObservableCollection<Load>> GetOverdue()
        {
            throw new NotImplementedException();
        }

        public Task<Load?> RemoveAsync(Load load)
        {
            throw new NotImplementedException();
        }
    }
}

using BLL.Services.Interfaces;
using DAL.Repositories;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Design.Serialization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    internal class LoadService : ILoadSerivce
    {

        private readonly LoadRepository _loadRepository;

        public LoadService(LoadRepository loadRepository)
        {
            _loadRepository = loadRepository;
        }



        public async Task<Load?> AddAsync(Load load)
        {
            return await _loadRepository.CreateAsync(load);
        }

        public async Task<ObservableCollection<Load>> GetAllAsync()
        {
            return await _loadRepository.GetAllAsync();
        }

        public async Task<Load?> GetAsync(int id)
        {
            return await _loadRepository.FindFirstAsync(load => load.Id == id);
        }

        public async Task<ObservableCollection<Load>> GetByBookAsync(int bookId)
        {
            return await _loadRepository.FindByConditionalAsync(load => load.Books.Any(book => book.Id == bookId));
        }

        public async Task<ObservableCollection<Load>> GetByStudent(int studentId)
        {
            return await _loadRepository.FindByConditionalAsync(load => load.StudentId == studentId);
        }

        public async Task<ObservableCollection<Load>> GetOverdue()
        {
            return await _loadRepository.FindByConditionalAsync(load => load.ReturnDate < DateTime.Now);
        }

        public async Task RemoveAsync(int id)
        {
            await _loadRepository.DeleteAsync(load => load.Id == id);
        }

    }
}

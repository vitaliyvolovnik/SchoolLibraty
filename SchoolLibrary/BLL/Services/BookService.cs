using BLL.Services.Interfaces;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    internal class BookService : IBookService, IBookCollectionService
    {
        public Task<Book?> AddAsync(Book book)
        {
            throw new NotImplementedException();
        }

        public Task<BookCollection?> AddAsync(BookCollection collection)
        {
            throw new NotImplementedException();
        }

        public Task<Book?> AddCountAsync(int id, int count)
        {
            throw new NotImplementedException();
        }

        public Task<ObservableCollection<Book>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Book?> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ObservableCollection<Book>> GetByAuthorAsync(int authorId)
        {
            throw new NotImplementedException();
        }

        public Task<ObservableCollection<Book>> GetByAuthorAsync(Person person)
        {
            throw new NotImplementedException();
        }

        public Task<ObservableCollection<Book>> GetByStrAsync(string text)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<ObservableCollection<BookCollection>> IBookCollectionService.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<BookCollection?> IBookCollectionService.GetAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}

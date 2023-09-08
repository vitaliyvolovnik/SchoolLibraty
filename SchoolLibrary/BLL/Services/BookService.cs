using BLL.Services.Interfaces;
using DAL.Repositories;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class BookService : IBookService, IBookCollectionService
    {

        private readonly BookRepository _bookRepository;
        private readonly BookCollectionRepository _bookCollectionRepository;



        public BookService(BookRepository bookRepository, BookCollectionRepository bookCollectionRepository)
        {
            _bookCollectionRepository = bookCollectionRepository;
            _bookRepository = bookRepository;
        }





        public async Task<Book?> AddAsync(Book book)
        {
            return await _bookRepository.CreateAsync(book);
        }

        public async Task<BookCollection?> AddAsync(BookCollection collection)
        {
            return await _bookCollectionRepository.CreateAsync(collection);
        }

        public async Task<Book?> AddCountAsync(int id, int count)
        {
            return await _bookRepository.AddCount(id, count);
        }

        public async Task<ObservableCollection<Book>> GetAllBookAsync()
        {
            return await _bookRepository.GetAllAsync();
        }

        public async Task<Book?> GetBookAsync(int id)
        {
            return await _bookRepository.FindFirstAsync(book => book.Id == id);
        }

        public async Task<ObservableCollection<Book>> GetByAuthorAsync(int authorId)
        {
            return await _bookRepository.FindByConditionalAsync(book => book.Authors.Any(author => author.Id == authorId));
        }

        public async Task<ObservableCollection<Book>> GetByAuthorAsync(Person person)
        {
            return await _bookRepository.FindByConditionalAsync(book => book.Authors
            .Any(author => author.Person.Firstname.Contains(person.Firstname)
                || author.Person.Lastname.Contains(person.Lastname)));
        }

        public async Task<ObservableCollection<Book>> GetByStrAsync(string text)
        {
            return await _bookRepository.FindByConditionalAsync(book =>
            book.Name.Contains(text) ||
            book.Year.Contains(text) ||
            book.Authors.Any(author => author.Person.Firstname.Contains(text)
                || author.Person.Lastname.Contains(text)));
        }

        public async Task RemoveBookAsync(int id)
        {
            await _bookRepository.DeleteAsync(book => book.Id == id);
        }

        public async Task<ObservableCollection<BookCollection>> GetAllCollectionsAsync()
        {
            return await _bookCollectionRepository.GetAllAsync();
        }

        public async Task<BookCollection?> GetCollectionAsync(int id)
        {
            return await _bookCollectionRepository.FindFirstAsync(book => book.Id == id);
        }
    }
}

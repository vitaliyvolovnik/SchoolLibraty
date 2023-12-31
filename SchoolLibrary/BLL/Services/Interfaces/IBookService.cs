﻿using Domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IBookService
    {
        Task<Book?> AddAsync(Book book);

        Task<Book?> GetBookAsync(int id);
        Task RemoveBookAsync(int id);

        Task<Book?> AddCountAsync(int id,int count);

        Task<ObservableCollection<Book>> GetAllBookAsync();
        Task<ObservableCollection<Book>> GetByAuthorAsync(int authorId);
        Task<ObservableCollection<Book>> GetByAuthorAsync(Person person);
        Task<ObservableCollection<Book>> GetByStrAsync(string text);

    }
}

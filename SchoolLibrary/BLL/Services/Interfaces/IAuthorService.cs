using Domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IAuthorService
    {

        Task<Author?> AddAsync(Author author);

        Task<ObservableCollection<Author>> GetAllAuthorsAsync();
    
       
    }
}

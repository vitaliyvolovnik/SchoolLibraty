using Domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IPersonService
    {
        Task<Person?> AddAsync(Person person);

        Task<Person?> UpdateAsync(Person person,int personId);
        Task RemoveAsync(Person person);
        Task<Person> GetAsync(int id);

        Task<ObservableCollection<Person>> GetAllAsync();
           
    }
}

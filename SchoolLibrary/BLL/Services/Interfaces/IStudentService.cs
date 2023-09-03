using Domain.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services.Interfaces
{
    public interface IStudentService
    {

        Task<Student?> AddAsync(Student student);

        Task<Student?> UpdateAsync(Student student,int studentId);
        Task RemoveAsync(int id);
        Task<Student> GetAsync(int id);
        
        Task<ObservableCollection<Student>> GetAllAsync();
        Task<ObservableCollection<Student>> GetByNameAsync(Person person);
        Task<ObservableCollection<Student>> GetByClassAsync(int Class);

    }
}

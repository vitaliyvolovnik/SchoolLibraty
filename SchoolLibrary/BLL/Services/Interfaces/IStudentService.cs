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
        Task RemoveStudentAsync(int studentId);
        Task<Student> GetStudentAsync(int id);
        
        Task<ObservableCollection<Student>> GetAllStudentsAsync();
        Task<ObservableCollection<Student>> GetByNameAsync(Person person);
        Task<ObservableCollection<Student>> GetByClassAsync(int Class);

    }
}

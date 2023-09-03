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
    public class PersonService : IPersonService, IStudentService, IAuthorService
    {
        public Task<Person?> AddAsync(Person person)
        {
            throw new NotImplementedException();
        }

        public Task<Student?> AddAsync(Student student)
        {
            throw new NotImplementedException();
        }

        public Task<Author?> AddAsync(Author author)
        {
            throw new NotImplementedException();
        }

        public Task<ObservableCollection<Person>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Person> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ObservableCollection<Student>> GetByClassAsync(int Class)
        {
            throw new NotImplementedException();
        }

        public Task<ObservableCollection<Student>> GetByNameAsync(Person person)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(Person person)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Person?> UpdateAsync(Person person, int personId)
        {
            throw new NotImplementedException();
        }

        public Task<Student?> UpdateAsync(Student student, int studentId)
        {
            throw new NotImplementedException();
        }

        Task<ObservableCollection<Student>> IStudentService.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<ObservableCollection<Author>> IAuthorService.GetAllAsync()
        {
            throw new NotImplementedException();
        }

        Task<Student> IStudentService.GetAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}

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
    public class PersonService : IPersonService, IStudentService, IAuthorService
    {

        private readonly PersonRepository _personRepository;
        private readonly StudentRepository _studentRepository;
        private readonly AuthorRepository _authorRepository;

        public PersonService(PersonRepository personRepository, StudentRepository studentRepository, AuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
            _personRepository = personRepository;
            _studentRepository = studentRepository;
        }


        public async Task<Person?> AddAsync(Person person)
        {
            return await _personRepository.CreateAsync(person);
        }

        public async Task<Student?> AddAsync(Student student)
        {
            return await _studentRepository.CreateAsync(student);
        }

        public Task<Author?> AddAsync(Author author)
        {
            return _authorRepository.CreateAsync(author);
        }

        public async Task<ObservableCollection<Person>> GetAllPersonsAsync()
        {
            return await _personRepository.GetAllAsync();
        }

        public async Task<Person?> GetPersonAsync(int id)
        {
            return await _personRepository.FindFirstAsync(person => person.Id == id);
        }

        public Task<ObservableCollection<Student>> GetByClassAsync(int Class)
        {
            return _studentRepository.FindByConditionalAsync(student => student.Class == Class);
        }

        public async Task<ObservableCollection<Student>> GetByNameAsync(Person person)
        {
            //to do:Change method signature
            throw new NotImplementedException();
        }

        public async Task RemoveAsync(Person person)
        {
            await _personRepository.DeleteAsync(x => x.Id == person.Id ||
                (x.Firstname.Equals(person.Firstname) && x.Lastname.Equals(person.Lastname)));
        }

        public async Task RemoveStudentAsync(int studentId)
        {
            await _studentRepository.DeleteAsync(student => student.Id == studentId);
        }

        public async Task<Person?> UpdateAsync(Person person, int personId)
        {
            return await _personRepository.UpdateAsync(person, personId);
        }

        public async Task<Student?> UpdateAsync(Student student, int studentId)
        {
            return await _studentRepository.UpdateAsync(student, studentId);
        }

        public async Task<ObservableCollection<Student>> GetAllStudentsAsync()
        {
            return await _studentRepository.GetAllAsync();
        }

        public async Task<ObservableCollection<Author>> GetAllAuthorsAsync()
        {
            return await _authorRepository.GetAllAsync();
        }

        public async Task<Student?> GetStudentAsync(int id)
        {
            return await _studentRepository.FindFirstAsync(stundet => stundet.Id == id);
        }
    }
}

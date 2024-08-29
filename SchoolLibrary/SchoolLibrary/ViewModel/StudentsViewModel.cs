using BLL.Services;
using Domain.Models;
using Microsoft.EntityFrameworkCore.Diagnostics;
using SchoolLibrary.Infrastructure.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SchoolLibrary.ViewModel
{
    public class StudentsViewModel : BaseViewModel
    {

        private readonly PersonService _personService;


        public StudentsViewModel(PersonService personService)
        {
            _personService = personService;

            Initialize();
        }

        private async void Initialize()
        {
            Students = await _personService.GetAllStudentsAsync();
        }

        private ObservableCollection<Student> students;
        public ObservableCollection<Student> Students
        {
            get { return students ??= new ObservableCollection<Student>(); }
            set
            {
                students = value;
                OnPropertyChanged(nameof(Students));
            }
        }

        public string StudentListVisibility
        {
            get
            {
                return !(isNewStudentVisibility || isSelectedStudentVisibility) ? "Visible" : "Collapsed";
            }
        }

        #region SelectedStudent
        private Student student;
        public Student Student
        {
            get { return student; }
            set { student = value; OnPropertyChanged(nameof(Student)); }
        }

        private bool isSelectedStudentVisibility;

        private bool IsSelectedStudentVisibility
        {
            get
            {
                return isSelectedStudentVisibility;
            }
            set
            {
                isSelectedStudentVisibility = value;
                OnPropertyChanged(nameof(SelectedStudentVisibility));
                OnPropertyChanged(nameof(StudentListVisibility));
            }
        }

        public string SelectedStudentVisibility
        {
            get { return IsSelectedStudentVisibility ? "Visible" : "Collapsed"; }
        }

        private ICommand selectStudentCommand;

        public ICommand SelectStudentCommand => selectStudentCommand ??= new AsyncRelayCommand(SelectStudentExecute);

        private async Task SelectStudentExecute(object arg)
        {
            var studentId = (int)arg;

            Student = await _personService.GetStudentAsync(studentId);
            IsSelectedStudentVisibility = true;
        }


        private ICommand closeSelectedStudentCommand;

        public ICommand CloseSelectedStudentCommand => closeSelectedStudentCommand ??= new RelayCommand(CloseSelectedStudentExecute);

        private void CloseSelectedStudentExecute(object obj)
        {
            IsSelectedStudentVisibility = false;
        }

        #endregion


        #region NewStudent

        private Student newStudent;
        public Student NewStudent
        {
            get { return newStudent ??= new(); }
            set
            {
                newStudent = value;
                OnPropertyChanged(nameof(newStudent));
            }
        }

        private bool isNewStudentVisibility;

        private bool IsNewStudentVisibility
        {
            get
            {
                return isNewStudentVisibility;
            }
            set
            {
                isNewStudentVisibility = value;
                OnPropertyChanged(nameof(NewStudentVisibility));
                OnPropertyChanged(nameof(IsNewStudentVisibility));
                OnPropertyChanged(nameof(StudentListVisibility));
            }
        }

        public string NewStudentVisibility
        {
            get { return IsNewStudentVisibility ? "Visible" : "Collapsed"; }
        }

        private ICommand closeNewStudentCommand;
        public ICommand CloseNewStudentCommand => closeNewStudentCommand ??= new RelayCommand(CloseNewStudentExecute);
        private void CloseNewStudentExecute(object obj)
        {
            IsNewStudentVisibility = false;
        }

        private ICommand openStudentCreateElement;
        public ICommand OpenStudentCreateElement => openStudentCreateElement ??= new RelayCommand(OpenStudentCreateElementExecute);
        private void OpenStudentCreateElementExecute(object obj)
        {
            IsNewStudentVisibility = true;
        }

        private ICommand addNewStudentCommand;
        public ICommand AddNewStudentCommand => addNewStudentCommand ??= new AsyncRelayCommand(AddNewStudentExecute, AddNewStudentCanExecute);

        private bool AddNewStudentCanExecute(object arg)
        {
            if (string.IsNullOrWhiteSpace(NewStudent.Person.Firstname) ||
               string.IsNullOrWhiteSpace(NewStudent.Person.Lastname) ||
               (NewStudent.Class <= 0 && NewStudent.Class >= 13))
                return false;


            return true;
        }

        private async Task AddNewStudentExecute(object arg)
        {
            var st = await _personService.AddAsync(newStudent);
            if (st != null)
                return;
            Students.Add(st);
            CloseNewStudentExecute(null);

        }

        #endregion

    }
}

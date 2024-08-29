using Microsoft.Extensions.DependencyInjection;
using SchoolLibrary.Infrastructure.Commands;
using SchoolLibrary.View.Pages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace SchoolLibrary.ViewModel
{
    public class MainViewModel:BaseViewModel
    {
        private Page? currentPage;



        public Page? CurrentPage
        {
            get { return currentPage; }
            set 
            { 
                currentPage = value;
                OnPropertyChanged(nameof(CurrentPage));
            }
        }


        #region Student
        private ICommand studentPageCommand;
        public ICommand StudentPageCommand => studentPageCommand ??= new RelayCommand(OpenStudentPageExecute);


        private Page? studentPage;
        private void OpenStudentPageExecute(object obj)
        {
            CurrentPage = studentPage ??= App.ServiceProvider.GetService<StudentPage>();
        }
        #endregion

        #region Book
        private ICommand bookPageCommand;
        public ICommand BookPageCommand => bookPageCommand ??= new RelayCommand(OpenBookPageExecute);


        private Page? bookPage;
        private void OpenBookPageExecute(object obj)
        {
            CurrentPage = bookPage ??= App.ServiceProvider.GetService<BookPage>();
        }
        #endregion

        #region Collection
        private ICommand collectionPageCommand;
        public ICommand CollectionPageCommand => collectionPageCommand ??= new RelayCommand(OpenCollectionPageExecute);


        private Page? bookCollectionPage;
        private void OpenCollectionPageExecute(object obj)
        {
            CurrentPage = bookCollectionPage ??= App.ServiceProvider.GetService<BookCollectionsPage>();
        }
        #endregion

        #region Load
        private ICommand loadPageCommand;
        public ICommand LoadPageCommand => loadPageCommand ??= new RelayCommand(OpenLoadPageExecute);


        private Page? loadPage;
        private void OpenLoadPageExecute(object obj)
        {
            CurrentPage = loadPage ??= App.ServiceProvider.GetService<LoadPage>();
        }
        #endregion


    }
}

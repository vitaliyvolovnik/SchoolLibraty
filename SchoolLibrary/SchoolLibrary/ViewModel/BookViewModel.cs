using BLL.Services;
using BLL.Services.Interfaces;
using Domain.Models;
using SchoolLibrary.Infrastructure.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SchoolLibrary.ViewModel
{
    public class BookViewModel : BaseViewModel
    {
        private readonly BookService _bookService;
        private readonly PersonService _personService;

        public BookViewModel(BookService bookService, PersonService personService)
        {
            this._bookService = bookService;
            Initialize();
            _personService = personService;
        }

        private ObservableCollection<Book> books;
        public ObservableCollection<Book> Books
        {
            get { return books ??= new ObservableCollection<Book>(); }
            set
            {
                books = value;
                OnPropertyChanged(nameof(Books));
            }
        }

        private ObservableCollection<Author> authors;
        public ObservableCollection<Author> Authors
        {
            get { return authors ??= new ObservableCollection<Author>(); }
            set
            {
                authors = value;
                OnPropertyChanged(nameof(Authors));
            }
        }

        private async void Initialize()
        {
            Books = await _bookService.GetAllBookAsync();
        }

        public string BookListVisibility
        {
            get
            {
                return !(isNewBookVisibility || isSelectedBookVisibility) ? "Visible" : "Collapsed";
            }
        }

        #region SelectedBook
        private Book book;
        public Book Book
        {
            get => book;
            set
            {
                book = value;
                OnPropertyChanged(nameof(Books));
            }
        }

        #region Visiblility
        private bool isSelectedBookVisibility;

        private bool IsSelectedBookVisibility
        {
            get
            {
                return isSelectedBookVisibility;
            }
            set
            {
                isSelectedBookVisibility = value;
                OnPropertyChanged(nameof(SelectedBookVisibility));
                OnPropertyChanged(nameof(BookListVisibility));
            }
        }

        public string SelectedBookVisibility
        {
            get { return IsSelectedBookVisibility ? "Visible" : "Collapsed"; }
        }


        private ICommand selectBookCommand;

        public ICommand SelectBookCommand => selectBookCommand ??= new AsyncRelayCommand(SelectBookExecute);

        private async Task SelectBookExecute(object arg)
        {
            var id = (int)arg;

            Book = await _bookService.GetBookAsync(id);
            IsSelectedBookVisibility = true;
        }


        private ICommand closeSelectedBookCommand;

        public ICommand CloseSelectedBookCommand => closeSelectedBookCommand ??= new RelayCommand(CloseSelectedBookExecute);

        private void CloseSelectedBookExecute(object obj)
        {
            IsSelectedBookVisibility = false;
        }

        #endregion


        #endregion


        #region NewBook
        private Book newBook;
        public Book NewBook
        {
            get { return newBook; }
            set
            {
                newBook = value;
                OnPropertyChanged(nameof(NewBook));
            }
        }

        private ICommand addNewBookCommand;
        public ICommand AddNewBookCommand => addNewBookCommand ??= new AsyncRelayCommand(AddNewBookExecute, AddNewBookCanExecute);

        private bool AddNewBookCanExecute(object arg)
        {
            if (string.IsNullOrWhiteSpace(NewBook.Name) ||
               string.IsNullOrWhiteSpace(NewBook.Year) ||
               (NewBook.Count >= 0))
                return false;


            return true;
        }

        private async Task AddNewBookExecute(object arg)
        {
            var st = await _bookService.AddAsync(NewBook);
            if (st != null)
                return;
            Books.Add(st);
            CloseNewBookExecute(null);

        }

        #region Visibility
        private bool isNewBookVisibility;

        private bool IsNewBookVisibility
        {
            get
            {
                return isNewBookVisibility;
            }
            set
            {
                isNewBookVisibility = value;
                OnPropertyChanged(nameof(NewBookVisibility));
                OnPropertyChanged(nameof(IsNewBookVisibility));
                OnPropertyChanged(nameof(BookListVisibility));
            }
        }

        public string NewBookVisibility
        {
            get { return IsNewBookVisibility ? "Visible" : "Collapsed"; }
        }


        private ICommand closeNewBookCommand;
        public ICommand CloseNewBookCommand => closeNewBookCommand ??= new RelayCommand(CloseNewBookExecute);
        private void CloseNewBookExecute(object obj)
        {
            IsNewBookVisibility = false;
        }

        private ICommand openBookCreateElement;
        public ICommand OpenBookCreateElement => openBookCreateElement ??= new RelayCommand(OpenBookCreateElementExecute);
        private void OpenBookCreateElementExecute(object obj)
        {
            IsNewBookVisibility = true;
        }
        #endregion
        #endregion
    }
}

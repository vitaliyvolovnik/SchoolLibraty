using BLL.Infrastructure;
using DAL.Context;
using Domain.Models;
using Microsoft.Extensions.DependencyInjection;
using SchoolLibrary.View.Pages;
using SchoolLibrary.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SchoolLibrary
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        public static IServiceProvider ServiceProvider { get; private set; }

        public App()
        {
            var collection = new ServiceCollection();
            ConfigureService(collection);
            ServiceProvider = collection.BuildServiceProvider();
        }

        private void Application_Startup(object sender, StartupEventArgs e)
        {
            var main = ServiceProvider.GetService<MainWindow>();
            main.Show();
        }


        private void ConfigureService(ServiceCollection collectoin)
        {
            //window and pages
            collectoin.AddTransient<MainWindow>();
            collectoin.AddTransient<StudentPage>();
            collectoin.AddTransient<BookPage>();
            collectoin.AddTransient<BookCollectionsPage>();
            collectoin.AddTransient<LoadPage>();


            //viewModels
            collectoin.AddTransient<MainViewModel>();
            collectoin.AddTransient<StudentsViewModel>();


            ConfigureBll.Configure(collectoin, "datasource=127.0.0.1;port=3306;username=root;password=;database=test2;");
        }
    }
}

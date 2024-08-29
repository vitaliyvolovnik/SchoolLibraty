using BLL.Services;
using DAL.Context;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;


namespace BLL.Infrastructure
{
    public static class ConfigureBll
    {

        public static void Configure(ServiceCollection collection, string connectionString)
        {
            var optionsBuilder = new DbContextOptionsBuilder<SchoolLibraryContext>();
            optionsBuilder.UseMySql(connectionString, new MySqlServerVersion(new Version(8, 0, 28)));

            //context
            collection.AddTransient<SchoolLibraryContext>(provider => new SchoolLibraryContext(optionsBuilder.Options));

            //repositories
            collection.AddTransient<AuthorRepository>();
            collection.AddTransient<BookCollectionRepository>();
            collection.AddTransient<BookRepository>();
            collection.AddTransient<LoadRepository>();
            collection.AddTransient<PersonRepository>();
            collection.AddTransient<StudentRepository>();


            //services
            collection.AddTransient<BookService>();
            collection.AddTransient<LoadService>();
            collection.AddTransient<PersonService>();


        }

    }
}

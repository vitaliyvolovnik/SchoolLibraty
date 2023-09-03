using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Context
{
    public class SchoolLibraryContext:DbContext
    {
        public SchoolLibraryContext(DbContextOptions<SchoolLibraryContext> options):base(options)
        {

            Database.EnsureCreated();
        }


        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookCollection> BookCollections { get; set; }
        public DbSet<Load> Loads { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Student> Students { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<Author>()
                .HasMany(author => author.Books)
                .WithMany(book => book.Authors);

            modelBuilder.Entity<Author>()
                .HasOne(author => author.Person)
                .WithOne()
                .IsRequired(false);


            modelBuilder.Entity<Book>()
                .HasMany(book => book.Collections)
                .WithMany(collection => collection.Books);

            modelBuilder.Entity<Load>()
                .HasOne(load => load.Student)
                .WithMany(student => student.Loads)
                .HasForeignKey(load => load.StudentId)
                .IsRequired(false);


            modelBuilder.Entity<Student>()
                .HasOne(student => student.Person)
                .WithOne()
                .IsRequired(false);



            base.OnModelCreating(modelBuilder);
        }

    }
}

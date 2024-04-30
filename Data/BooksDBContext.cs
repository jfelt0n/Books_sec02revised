using Books_sec02revised.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Books_sec02revised.Data
{
    public class BooksDBContext : IdentityDbContext<IdentityUser>
    {
        public BooksDBContext(DbContextOptions<BooksDBContext> options)
        : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public DbSet<Cart> Carts { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Category>().HasData(

                new Category { CategoryId = 1, Name = "Travel", Description = "This is the description for the travel category" },

                new Category { CategoryId = 2, Name = "Fiction", Description = "This is the description for the fiction category" },

                new Category { CategoryId = 3, Name = "Nonfiction", Description = "This is the description for the Nonfiction category" }

                );


            modelBuilder.Entity<Book>().HasData(


                new Book
                {

                    BookId = 1,
                    BookTitle = "The Wager",
                    Author = "David Grann",
                    Description = "A Tale of shipwreck, mutiny and murder",
                    Price = 19.99m,
                    CategoryId = 1

                },
                new Book
                {

                    BookId = 2,
                    BookTitle = "The Monster",
                    Author = "John Grann",
                    Description = "A Tale of shipwreck, murder",
                    Price = 16.99m,
                    CategoryId =2

                },
                new Book
                {

                    BookId = 3,
                    BookTitle = "The Man",
                    Author = "Eli Grann",
                    Description = "A Tale of shipwreck, mutiny ",
                    Price = 17.99m,
                    CategoryId =3

                }                );
        }

    }
}


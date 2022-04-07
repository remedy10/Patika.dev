using Microsoft.EntityFrameworkCore;
using webAPI.Entities;

namespace webAPI.DBOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (
                var context = new BookStoreDbContext(
                    serviceProvider.GetRequiredService<DbContextOptions<BookStoreDbContext>>()
                )!
            )
            {
                // Look for any book.
                if (context.Books.Any())
                {
                    return; // Data was already seeded
                }
                context.Genres.AddRange(
                    new Genre { Name = "nonCategorized" }, //1
                    new Genre { Name = "Sci-Fi" },
                    new Genre { Name = "Fantasy" }, //3
                    new Genre { Name = "Biography" },
                    new Genre { Name = "AutoBiography" }, //5
                    new Genre { Name = "Education" },
                    new Genre { Name = "Detective" },
                    new Genre { Name = "Action" } //8
                //! Genre ekliyorz
                );
                context.Authors.AddRange(
                    new Author
                    {
                        NameAndSurname = "JRR Tolkien",
                        DateOfBirth = new DateTime(1892, 01, 03) //1
                    },
                    new Author
                    {
                        NameAndSurname = "Chris Tolkien",
                        DateOfBirth = new DateTime(1924, 11, 21) //2
                    },
                    new Author
                    {
                        NameAndSurname = "Murat Menteş",
                        DateOfBirth = new DateTime(1974, 09, 01) //3
                    },
                    new Author
                    {
                        NameAndSurname = "Jack London",
                        DateOfBirth = new DateTime(1876, 01, 12) //4
                    }
                );
                context.Books.AddRange(
                    new Book
                    {
                        bookTitle = "Lord of the Rings",
                        bookPage = 1100,
                        bookRelase = new DateTime(1972, 01, 01),
                        AuthorId = 1,
                        genreId = 3 //Fantasy
                    },
                    new Book
                    {
                        bookTitle = "Hobbit",
                        bookPage = 400,
                        bookRelase = new DateTime(1937, 05, 07),
                        AuthorId = 1,
                        genreId = 3 //Fantasy
                    },
                    new Book
                    {
                        bookTitle = "Dublorün Dilemması",
                        bookPage = 200,
                        bookRelase = new DateTime(2010, 01, 01),
                        AuthorId = 3,
                        genreId = 8 //Action
                    },
                    new Book
                    {
                        bookTitle = "Ruhi Mücerret",
                        bookPage = 318,
                        bookRelase = new DateTime(2013, 01, 01),
                        AuthorId = 3,
                        genreId = 7 //Detective
                    },
                    new Book
                    {
                        bookTitle = "Beyaz Diş",
                        bookPage = 258,
                        bookRelase = new DateTime(1906, 01, 01),
                        AuthorId = 4,
                        genreId = 8 //Action
                    }
                );
                context.SaveChanges();
            }
        }
    }
}

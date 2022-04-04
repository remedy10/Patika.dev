using Microsoft.EntityFrameworkCore;

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
                context.Books.AddRange(
                    new Book
                    {
                        bookTitle = "Lord of the Rings",
                        bookPage = 1100,
                        bookRelase = new DateTime(1972, 1, 1),
                        genreId = 2 //Fantasy
                    },
                    new Book
                    {
                        bookTitle = "Hobbit",
                        bookPage = 400,
                        bookRelase = new DateTime(1937, 1, 1),
                        genreId = 2 //Fantasy
                    },
                    new Book
                    {
                        bookTitle = "Dublorün Dilemması",
                        bookPage = 200,
                        bookRelase = new DateTime(2010, 1, 1),
                        genreId = 6 //Detective
                    },
                    new Book
                    {
                        bookTitle = "Ruhi Mücerret",
                        bookPage = 318,
                        bookRelase = new DateTime(2013, 1, 1),
                        genreId = 7 //Detective
                    },
                    new Book
                    {
                        bookTitle = "Beyaz Diş",
                        bookPage = 258,
                        bookRelase = new DateTime(1906, 1, 1),
                        genreId = 0 //Detective
                    }
                );
                context.SaveChanges();
            }
        }
    }
}

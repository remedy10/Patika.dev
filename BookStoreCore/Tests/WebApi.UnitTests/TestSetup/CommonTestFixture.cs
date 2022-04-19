using Microsoft.EntityFrameworkCore;
using webAPI.DBOperations;

namespace WebApi.UnitTests.TestSetup
{
    public class CommonTestFixture
    {
        public CommonTestFixture()
        {
            var options =
                new DbContextOptionsBuilder<BookStoreDbContext>().UseInMemoryDatabase(
                    databaseName: "BookStoreDbContext.TestDataBase"
                ).Options;
            BookStoreDbContext = new BookStoreDbContext(options);
            BookStoreDbContext.Database.EnsureCreated();
            BookStoreDbContext.AddBooks();
            BookStoreDbContext.AddAuthor();
            BookStoreDbContext.AddGenre();
            BookStoreDbContext.SaveChanges();
        }

        public BookStoreDbContext BookStoreDbContext { get; set; }
    }
}

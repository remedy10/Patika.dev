using Microsoft.EntityFrameworkCore;
using webAPI.DBOperations;
using webAPI.Entities;

namespace webAPI.Applicaton.BookOperations.Queries.GetBooks
{
    public class GetBooksQuery
    {
        public readonly BookStoreDbContext _bookStoreDbContext;

        public GetBooksQuery(BookStoreDbContext bookStoreDbContext)
        {
            _bookStoreDbContext = bookStoreDbContext;
        }

        public List<BooksViewModel> GetQuery()
        { //Inlucde derken sqldeki join gibi düşün
            var bookList = _bookStoreDbContext.Books
                .Include(x => x.Genre)
                .Include(x => x.Author)
                .OrderBy(x => x.bookId)
                .ToList<Book>();
            List<BooksViewModel> vmList = new();
            foreach (var book in bookList)
            {
                vmList.Add(
                    new BooksViewModel()
                    {
                        Title = book.bookTitle,
                        Relase = book.bookRelase.Date.ToString("dd/mm/yyyy"),
                        Page = book.bookPage,
                        Genre = book.Genre.Name,
                        Author = book.Author.NameAndSurname
                    }
                );
            }
            return vmList;
        }

        public class BooksViewModel
        {
            // public int bookId { get; set; }
            public string Title { get; set; }
            public string Relase { get; set; }
            public int Page { get; set; }

            public string Genre { get; set; }
            public string Author { get; set; }
        }
    }
}

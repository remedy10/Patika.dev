using webAPI.DBOperations;
using webAPI.Enums;

namespace webAPI.Models.GetBooks
{
    public class GetBooksQuery
    {
        public readonly BookStoreDbContext _bookStoreDbContext;

        public GetBooksQuery(BookStoreDbContext bookStoreDbContext)
        {
            _bookStoreDbContext = bookStoreDbContext;
        }

        public List<BooksViewModel> GetQuery()
        {
            var bookList = _bookStoreDbContext.Books.OrderBy(x => x.bookId).ToList<Book>();
            List<BooksViewModel> vmList = new();
            foreach (var book in bookList)
            {
                vmList.Add(
                    new BooksViewModel()
                    {
                        Title = book.bookTitle,
                        Relase = book.bookRelase.Date.ToString("dd/mm/yyyy"),
                        Page = book.bookPage,
                        Genre = ((Genres)book.genreId).ToString()
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

            
        }
    }
}

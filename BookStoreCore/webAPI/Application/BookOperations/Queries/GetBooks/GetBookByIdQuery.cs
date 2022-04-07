using Microsoft.EntityFrameworkCore;
using webAPI.DBOperations;
using webAPI.Entities;

namespace webAPI.Applicaton.BookOperations.Queries.GetBooks
{
    public class GetBookByIdQuery
    {
        private readonly BookStoreDbContext _bookStoreDbContext;

        public GetBookByIdQuery(BookStoreDbContext bookStoreDbContext)
        {
            _bookStoreDbContext = bookStoreDbContext;
        }

        public BooksViewModel Handle(int Id)
        {
            var book = _bookStoreDbContext.Books
                .Include(x => x.Genre)
                .Include(x => x.Author)
                .Where(book => book.bookId == Id)
                .SingleOrDefault()!;
            if (book == null)
                throw new Exception("Kitap bulunamadı");
            BooksViewModel bks = book;
            return bks; //direkt book desen de fark etmez
        }

        public class BooksViewModel
        {
            public string Title { get; set; }
            public string Relase { get; set; }
            public int Page { get; set; }

            public string Genre { get; set; }
            public string Author { get; set; }

            public static implicit operator BooksViewModel(Book model) =>
                new BooksViewModel
                {
                    Title = model.bookTitle,
                    Relase = model.bookRelase.Date.ToString("dd/MM/yyyy"),
                    Page = model.bookPage,
                    Genre = model.Genre.Name, //yeni geldi eskisi enumdu
                    Author = model.Author.NameAndSurname
                }; //kullanırız bir ara
        }
    }
}

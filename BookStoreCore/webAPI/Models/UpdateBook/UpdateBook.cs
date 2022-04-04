using webAPI.DBOperations;
using static webAPI.Models.UpdateBook.UpdateBook;

namespace webAPI.Models.UpdateBook
{
    public class UpdateBook
    {
        public UpdateModel MyModel { get; set; }
        private readonly BookStoreDbContext _bookStoreDbContext;

        public UpdateBook(BookStoreDbContext bookStoreDbContext)
        {
            _bookStoreDbContext = bookStoreDbContext;
        }

        public void Handle(int id)
        {
            var book = _bookStoreDbContext.Books.SingleOrDefault(x => x.bookId == id);
            if (book == null)
                throw new Exception("Hatalı giriş");
            book.bookId = upBook.bookId != default ? upBook.bookId : book.bookId;
            //ternary if şeklinde diyoruz ki , gelen değer default değilse(yani boş değilse) gelen değeri book id olarak ata
            // eğer boşşa kendi değerini kullan diyoruz
            book.bookPage = upBook.bookPage != default ? upBook.bookPage : book.bookPage;
            book.bookRelase = upBook.bookRelase != default ? upBook.bookRelase : book.bookRelase;
            book.bookTitle = upBook.bookTitle != default ? upBook.bookTitle : book.bookTitle;
            _context.SaveChanges();
        }

        public class UpdateModel
        {
            public string bookTitle { get; set; }
            public DateTime bookRelase { get; set; }
            public int bookPage { get; set; }

            public int genreId { get; set; }
        }
    }
}

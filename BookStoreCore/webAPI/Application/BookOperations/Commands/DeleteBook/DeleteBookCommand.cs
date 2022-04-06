using webAPI.DBOperations;
using webAPI.Entities;

namespace webAPI.Applicaton.BookOperations.Commands.DeleteBook
{
    public class DeleteBookCommand
    {
        public Book MyBook { get; set; }
        private readonly BookStoreDbContext _bookStoreDbContext;

        public DeleteBookCommand(BookStoreDbContext bookStoreDbContext)
        {
            _bookStoreDbContext = bookStoreDbContext;
        }

        public void Handle(int id)
        {
            var book = _bookStoreDbContext.Books.SingleOrDefault(x => x.bookId == id);
            if (book == null)
                throw new InvalidOperationException("Bulunamadı");
            _bookStoreDbContext.Books.Remove(book);
            _bookStoreDbContext.SaveChanges();
        }
    }
}

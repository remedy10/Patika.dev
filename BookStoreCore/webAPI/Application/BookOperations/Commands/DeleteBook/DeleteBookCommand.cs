using webAPI.DBOperations;
using webAPI.Entities;

namespace webAPI.Applicaton.BookOperations.Commands.DeleteBook
{
    public class DeleteBookCommand
    {
        public Book MyBook { get; set; }
        private readonly IBookStoreDbContext _bookStoreDbContext;

        public DeleteBookCommand(IBookStoreDbContext bookStoreDbContext)
        {
            _bookStoreDbContext = bookStoreDbContext;
        }

        public void Handle(int id)
        {
            var book = _bookStoreDbContext.Books.SingleOrDefault(x => x.bookId == id);
            if (book is null)
                throw new InvalidOperationException("Bulunamadı");
            _bookStoreDbContext.Books.Remove(book);
            _bookStoreDbContext.SaveChanges();
        }
    }
}

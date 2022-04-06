using webAPI.DBOperations;
using webAPI.Entities;

namespace webAPI.Applicaton.BookOperations.Commands.CreateBook
{
    public class CreateBookCommand
    {
        public CreateModel MyCreateModel { get; set; }
        public readonly BookStoreDbContext _bookStoreDbContext;

        public CreateBookCommand(BookStoreDbContext bookStoreDbContext)
        {
            _bookStoreDbContext = bookStoreDbContext;
        }

        public void Handle()
        {
            var book = _bookStoreDbContext.Books.SingleOrDefault(
                x => x.bookTitle == MyCreateModel.bookTitle
            ); //yeni eklediğimiz kitap var mı kontrol edelim
            if (book != null)
                throw new InvalidOperationException("Girdiğiniz kitap zaten var.");

            
            _bookStoreDbContext.Books.Add(MyCreateModel);
            _bookStoreDbContext.SaveChanges();
        }

        public class CreateModel
        {
            public string bookTitle { get; set; }
            public DateTime bookRelase { get; set; }
            public int bookPage { get; set; }

            public int genreId { get; set; }

            

            public static implicit operator Book(CreateModel createModel) =>
                new Book
                {
                    bookTitle = createModel.bookTitle,
                    bookRelase = createModel.bookRelase,
                    bookPage = createModel.bookPage,
                    genreId = createModel.genreId
                };
        }
    }
}

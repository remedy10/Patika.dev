using webAPI.DBOperations;

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
            //ternary if şeklinde diyoruz ki , gelen değer default değilse(yani boş değilse) gelen değeri book id olarak ata
            // eğer boşşa kendi değerini kullan diyoruz
            book.bookPage = MyModel.bookPage != default ? MyModel.bookPage : book.bookPage;
            book.bookRelase = MyModel.bookRelase != default ? MyModel.bookRelase : book.bookRelase;
            book.bookTitle = MyModel.bookTitle != default ? MyModel.bookTitle : book.bookTitle;
            book.genreId = MyModel.genreId != default ? MyModel.genreId : book.genreId;
            _bookStoreDbContext.SaveChanges();
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

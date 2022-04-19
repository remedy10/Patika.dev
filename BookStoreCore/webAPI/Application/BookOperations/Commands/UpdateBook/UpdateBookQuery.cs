using Microsoft.EntityFrameworkCore;
using webAPI.DBOperations;

namespace webAPI.Applicaton.BookOperations.Commands.UpdateBook
{
    public class UpdateBookQuery
    {
        public UpdateModel MyModel { get; set; }
        private readonly IBookStoreDbContext _bookStoreDbContext;

        public UpdateBookQuery(IBookStoreDbContext bookStoreDbContext)
        {
            _bookStoreDbContext = bookStoreDbContext;
        }

        public void Handle(int id)
        {
            var book = _bookStoreDbContext.Books
                .Include(x => x.Genre)
                .SingleOrDefault(x => x.bookId == id);
            if (book == null)
                throw new Exception("Hatalı giriş");
            var checkGenre = _bookStoreDbContext.Genres.SingleOrDefault(
                x => x.Id == MyModel.genreId
            );
            if (checkGenre == null)
                throw new InvalidOperationException(
                    "Genre Bulunamadı.Doğru bir genre adı giriniz.Yoksa Ekleyin"
                );
            var checkAuthor = _bookStoreDbContext.Authors.SingleOrDefault(
                x => x.Id == MyModel.authorId
            );
            if (checkAuthor is null)
                throw new InvalidOperationException("Geçerli bir author giriniz.");
            //ternary if şeklinde diyoruz ki , gelen değer default değilse(yani boş değilse) gelen değeri book id olarak ata
            // eğer boşşa kendi değerini kullan diyoruz AUTHOR KISMINDAKİ DAHA İYİ
            book.bookPage = MyModel.bookPage != default ? MyModel.bookPage : book.bookPage;
            book.bookRelase = MyModel.bookRelase != default ? MyModel.bookRelase : book.bookRelase;
            book.bookTitle = MyModel.bookTitle != default ? MyModel.bookTitle : book.bookTitle;
            book.genreId = MyModel.genreId != default ? MyModel.genreId : book.genreId;
            book.AuthorId = MyModel.authorId != default ? MyModel.authorId : book.AuthorId;
            _bookStoreDbContext.SaveChanges();
        }

        public class UpdateModel
        {
            public string bookTitle { get; set; }
            public DateTime bookRelase { get; set; }
            public int bookPage { get; set; }

            public int genreId { get; set; }
            public int authorId { get; set; }
        }
    }
}

using webAPI.DBOperations;
using webAPI.Entities;

namespace webAPI.Application.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommand
    {
        public DeleteGenreModel DeleteModel { get; set; }
        private readonly BookStoreDbContext _bookStoreDbContext;

        public DeleteGenreCommand(BookStoreDbContext bookStoreDbContext)
        {
            _bookStoreDbContext = bookStoreDbContext;
        }

        public void Handle(int id)
        {
            var tempGenre = _bookStoreDbContext.Genres.SingleOrDefault(x => x.Id == id);
            if (tempGenre is null)
                throw new InvalidOperationException("Genre Bulunamadı!");
            _bookStoreDbContext.Genres.Remove(tempGenre);
            _bookStoreDbContext.SaveChanges();
        }

        public class DeleteGenreModel
        {
            public int Id { get; set; }
            public int Name { get; set; }
        }
    }

    // TODO: Bunu için model oluştumaya gerek duymadım ama gerekirse refactor edebiliriz.
    // TODO: Validtor kullanmaıyorum artık yıldırdı.ama yinede validatorlü bir çözüm üret
    // TODO: aslında burada validasyon gereksiz ama
}

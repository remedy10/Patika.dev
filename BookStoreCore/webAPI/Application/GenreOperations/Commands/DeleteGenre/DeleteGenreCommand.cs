using webAPI.DBOperations;
using webAPI.Entities;

namespace webAPI.Application.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreCommand
    {
        public Genre MyGenre { get; set; }
        public int genreID { get; set; }//! gereksiz.
        private readonly BookStoreDbContext _bookStoreDbContext;

        public DeleteGenreCommand(BookStoreDbContext bookStoreDbContext)
        {
            _bookStoreDbContext = bookStoreDbContext;
        }

        public void Handle()
        {
            var tempGenre = _bookStoreDbContext.Genres
                .Where(x => x.Id == MyGenre.Id)
                .SingleOrDefault();
            if (tempGenre is null)
                throw new InvalidOperationException("Genre Bulunamadı!");
            _bookStoreDbContext.Genres.Remove(tempGenre);
            _bookStoreDbContext.SaveChanges();
        }
    }

    // TODO: Bunu için model oluştumaya gerek duymadım ama gerekirse refactor edebiliriz.
}

using webAPI.DBOperations;

namespace webAPI.Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommand
    {
        public int updatedGenreId { get; set; }
        public UpdateGenreModel UpdateModel { get; set; }

        private readonly IBookStoreDbContext _bookStoreDbContext;

        public UpdateGenreCommand(IBookStoreDbContext bookStoreDbContext)
        {
            _bookStoreDbContext = bookStoreDbContext;
        }

        public void Handle()
        {
            var tempGenre = _bookStoreDbContext.Genres.SingleOrDefault(x => x.Id == updatedGenreId);
            if (tempGenre is null)
                throw new InvalidOperationException("Genre Bulunamadı.");
            if (
                _bookStoreDbContext.Genres.Any(
                    x => x.Name.ToLower() == UpdateModel.Name.ToLower() && x.Id != updatedGenreId
                )
            )
                throw new InvalidOperationException("Ayni isimde bir Genre zaten mevcut");
            tempGenre.Name = UpdateModel.Name.Trim() != default ? UpdateModel.Name : tempGenre.Name;
            _bookStoreDbContext.SaveChanges();
        }
    }
    public class UpdateGenreModel
    {
        public string Name { get; set; }
    }
}

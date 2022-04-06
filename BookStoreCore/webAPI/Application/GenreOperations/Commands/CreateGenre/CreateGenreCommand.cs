using webAPI.DBOperations;
using webAPI.Entities;

namespace webAPI.Application.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreCommand
    {
        public CreateGenreModel MyCreateModel { get; set; }
        private readonly BookStoreDbContext _bookStoreDbContext;

        public CreateGenreCommand(BookStoreDbContext bookStoreDbContext)
        {
            _bookStoreDbContext = bookStoreDbContext;
        }

        public void Handle()
        {
            var addGenre = _bookStoreDbContext.Genres.SingleOrDefault(
                x => x.Name == MyCreateModel.Name
            );
            if (addGenre != null)
                throw new InvalidOperationException("Genre zaten var.");

            _bookStoreDbContext.Genres.Add(MyCreateModel);
            _bookStoreDbContext.SaveChanges();
        }
    }

    public class CreateGenreModel
    {
        public string Name { get; set; }

        public static implicit operator Genre(CreateGenreModel model) =>
            new Genre { Name = model.Name };
    }
}

using webAPI.DBOperations;
using webAPI.Entities;

namespace webAPI.Application.GenreOperations.Queries.GetGenres
{
    public class GetGenresByIdQuery
    {
        private readonly IBookStoreDbContext _bookStoreDbContext;

        public GetGenresByIdQuery(IBookStoreDbContext bookStoreDbContext)
        {
            _bookStoreDbContext = bookStoreDbContext;
        }

        public GenreViewModel Handle(int Id)
        {
            var returnobj = _bookStoreDbContext.Genres
                .Where(genre => genre.Id == Id)
                .SingleOrDefault();
            if (returnobj is null)
            {
                throw new Exception("Genre bulunamad─▒!");
            }
            return returnobj;
        }
    }

    public class GenreViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public static implicit operator GenreViewModel(Genre model) =>
            new GenreViewModel { Id = model.Id, Name = model.Name };
    }
}

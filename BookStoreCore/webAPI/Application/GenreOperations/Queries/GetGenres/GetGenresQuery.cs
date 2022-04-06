using webAPI.DBOperations;
using webAPI.Entities;
using webAPI.Enums;

namespace webAPI.Application.GenreOperations.Queries.GetGenres
{
    public class GetGenresQuery
    {
        private readonly BookStoreDbContext _bookStoreDbContext;

        public GetGenresQuery(BookStoreDbContext bookStoreDbContext)
        {
            _bookStoreDbContext = bookStoreDbContext;
        }

        public List<GenresViewModel> Handle()
        {
            var genreList = _bookStoreDbContext.Genres.OrderBy(x => x.Id).ToList<Genre>();
            List<GenresViewModel> genresViewModels = new();
            foreach (var genre in genreList)
            {
                genresViewModels.Add(new GenresViewModel { Name = genre.Name });
            }
            return genresViewModels; //?Kütüphane veya  implict&expilict veya reflection kullanabilirsin.
        }
    }

    public class GenresViewModel
    {
        public string Name { get; set; }
    }
}

using webAPI.DBOperations;
using webAPI.Entities;

namespace WebApi.UnitTests.TestSetup
{
    public static class Genres
    {
        public static void AddGenre(this BookStoreDbContext context)
        {
            context.Genres.AddRange(
                new Genre { Name = "nonCategorized" }, //1
                new Genre { Name = "Sci-Fi" },
                new Genre { Name = "Fantasy" }, //3
                new Genre { Name = "Biography" },
                new Genre { Name = "AutoBiography" }, //5
                new Genre { Name = "Education" },
                new Genre { Name = "Detective" },
                new Genre { Name = "Action" } //8
            );
        }
    }
}

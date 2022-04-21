using Microsoft.EntityFrameworkCore;
using MovieStore.WebAPI.Entites.Movie;

namespace MovieStore.WebAPI.DbOperations
{
    public class MovieStoreDbContext : DbContext
    {
        public MovieStoreDbContext(DbContextOptions<MovieStoreDbContext> options) : base(options)
        { }

        public DbSet<Movie> Movies { get; set; }
    }
}

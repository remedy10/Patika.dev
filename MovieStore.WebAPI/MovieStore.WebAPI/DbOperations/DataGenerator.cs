using Microsoft.EntityFrameworkCore;

namespace MovieStore.WebAPI.DbOperations
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (
                var context = new MovieStoreDbContext(
                    serviceProvider.GetRequiredService<DbContextOptions<MovieStoreDbContext>>()
                )
            )
            {
                if (context.Movies.Any())
                    return;
                context.Movies.AddRange(new Movie{M});
            }
        }
    }
}

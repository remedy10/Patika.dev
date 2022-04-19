using System.ComponentModel.DataAnnotations.Schema;
using MovieStore.WebAPI.Entites.Actor_Actress;

namespace MovieStore.WebAPI.Entites.Movie
{
    public class Movie
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int MovieId { get; set; }
        public String? MovieName { get; set; }
        public DateTime MovieYear { get; set; }
        public Enum? MovieGenre { get; set; }
        public long MoviePrice { get; set; }
        public List<Actor>? Cast { get; set; }
        public MovieStore.WebAPI.Entites.Director.Director? Director { get; set; }
    }
}

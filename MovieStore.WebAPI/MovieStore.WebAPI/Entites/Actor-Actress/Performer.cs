namespace MovieStore.WebAPI.Entites.Actor_Actress
{
    public abstract class Performer
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public List<MovieStore.WebAPI.Entites.Movie.Movie>? Movies { get; set; }
    }
}

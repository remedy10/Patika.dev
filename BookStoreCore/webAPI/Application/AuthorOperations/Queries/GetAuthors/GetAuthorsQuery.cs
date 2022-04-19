using webAPI.DBOperations;
using webAPI.Entities;

namespace webAPI.Application.AuthorOperations.Queries.GetAuthors
{

    public class GetAuthorsQuery
    {
        private readonly IBookStoreDbContext _dbContext;

        public GetAuthorsQuery(IBookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public List<AuthorsGetModel> Handle()
        {
            var authors = _dbContext.Authors.OrderBy(x => x.Id).ToList<Author>();
            List<AuthorsGetModel> models = new();
            authors.ForEach(x => models.Add(x));
            return models;
        }
    }

    public class AuthorsGetModel
    {
        public string NameAndSurname { get; set; }
        public string BirthOfDate { get; set; }

        public static implicit operator AuthorsGetModel(Author model) =>
            new AuthorsGetModel
            {
                NameAndSurname = model.NameAndSurname,
                BirthOfDate = model.DateOfBirth.ToString("dd/MM/yyyy")
            };
    }
}

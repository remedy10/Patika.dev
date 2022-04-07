using webAPI.DBOperations;
using webAPI.Entities;

namespace webAPI.Application.AuthorOperations.Queries.GetAuthors
{
    public class GetAuthorByIdQuery
    {
        private readonly BookStoreDbContext _dbContext;

        public GetAuthorByIdQuery(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public AuthorGetByIdModel Handle(int id)
        {
            var getAuthor = _dbContext.Authors.Where(x => x.Id == id).SingleOrDefault();
            if (getAuthor is null)
                throw new InvalidOperationException("Yazar Bulunamadı.");
            return getAuthor; //implicit methor sayasinde otomatik olarak Author=>AuthorGetByIdModel'e dönüşür
        }
    }

    public class AuthorGetByIdModel
    {
        public string NameAndSurname { get; set; }
        public string DateOfBirth { get; set; }

        public static implicit operator AuthorGetByIdModel(Author model) =>
            new AuthorGetByIdModel
            {
                NameAndSurname = model.NameAndSurname,
                DateOfBirth = model.DateOfBirth.ToString("dd/MM/yyyy")
            };
    }
}

using webAPI.DBOperations;
using webAPI.Entities;

namespace webAPI.Application.AuthorOperations.Queries.GetAuthors
{
    public class GetAuthorByName
    {
        //! Ekstra xD
        //! istediğim gibi olmadı sonra tekrar bakcağım şimdilik devre dışı
        //TODO: Boşluklarda ve eksiklerde çalışmıyor yapacaksan iyi birşeyler yap 
        private readonly IBookStoreDbContext _dbContext;

        public GetAuthorByName(IBookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public AuthorByNameModel Handle(string NameAndSurname)
        {
            var GetAuthorByName = _dbContext.Authors
                .Where(x => x.NameAndSurname.Trim(' ').ToLower() == NameAndSurname.Trim(' ').ToLower())
                .SingleOrDefault();
            if (GetAuthorByName is null)
                throw new InvalidOperationException("Yazar bulunamadı!");
            return GetAuthorByName;
        }
    }

    public class AuthorByNameModel
    { //! acayip kod tekrarı yaptın moruk
        public string NameAndSurname { get; set; }
        public string DateOfBirth { get; set; }

        public static implicit operator AuthorByNameModel(Author model) =>
            new AuthorByNameModel
            {
                NameAndSurname = model.NameAndSurname,
                DateOfBirth = model.DateOfBirth.ToString("dd/MM/yyyy")
            };
    }
}

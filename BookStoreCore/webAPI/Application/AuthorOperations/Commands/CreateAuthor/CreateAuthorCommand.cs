using webAPI.DBOperations;
using webAPI.Entities;

namespace webAPI.Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommand
    {
        public CreateAuthorModel MyCreateModel { get; set; }
        private readonly IBookStoreDbContext _dbContext;

        public CreateAuthorCommand(IBookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle()
        {
            //TODO: IsExist kontrolünde case sens.'e dikkat et  bir türlü yapamadın!
            var x = _dbContext.Authors.Where(
                x =>
                    x.NameAndSurname.Trim().ToLower()
                    == MyCreateModel.NameAndSurname.Trim().ToLower()
            );
            var checkAuthor = _dbContext.Authors
                .Where(
                    x =>
                        x.NameAndSurname.Trim().ToLower()
                        == MyCreateModel.NameAndSurname.Trim().ToLower()
                )
                .SingleOrDefault();
            if (checkAuthor != null)
                throw new InvalidOperationException("Yazar zaten mevcut");
            _dbContext.Authors.Add(MyCreateModel);
            _dbContext.SaveChanges();
        }
    }

    public class CreateAuthorModel
    {
        public string NameAndSurname { get; set; }
        public DateTime BirthOfDate { get; set; }

        public static implicit operator Author(CreateAuthorModel model) =>
            new Author { NameAndSurname = model.NameAndSurname, DateOfBirth = model.BirthOfDate };
    }
}

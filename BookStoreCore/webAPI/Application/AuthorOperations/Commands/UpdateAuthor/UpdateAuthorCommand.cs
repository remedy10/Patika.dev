using webAPI.DBOperations;

namespace webAPI.Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommand
    {
        public AuthorUpdateModel MyModel { get; set; }
        private readonly BookStoreDbContext _dbContext;

        public UpdateAuthorCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle(int id)
        {
            var temp = _dbContext.Authors.SingleOrDefault(x => x.Id == id);
            if (temp is null)
                throw new InvalidOperationException("Bulunamadı!");
            if (
                _dbContext.Authors.Any(
                    x =>
                        x.NameAndSurname.Trim().ToLower() == MyModel.NameAndSurname.Trim().ToLower()
                        && x.Id != id
                )
            )
                throw new InvalidOperationException("Yazar Zaten Mevcut ");
            temp.NameAndSurname = String.IsNullOrEmpty(MyModel.NameAndSurname) //eğer gelen boş veya null ise
              ? temp.NameAndSurname //önceki değer korunacak.
              : MyModel.NameAndSurname; //değilse yeni değeri atacak
            temp.DateOfBirth = MyModel.DateOfBirth.Date;
            _dbContext.SaveChanges();
        }
    }

    public class AuthorUpdateModel
    {
        public string NameAndSurname { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}

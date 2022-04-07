using Microsoft.EntityFrameworkCore;
using webAPI.DBOperations;

namespace webAPI.Application.AuthorOperations.Commands.DeleteAuthor
{
    public class DeleteAuthorCommand
    {
        private readonly BookStoreDbContext _dbContext;

        public DeleteAuthorCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Handle(int id)
        {
            var temp = _dbContext.Authors.SingleOrDefault(x => x.Id == id);
            if (temp is null)
                throw new InvalidOperationException("Bulunamadı!");
            var kitap = _dbContext.Books.Where(x => x.AuthorId == id); //selectordef. calısmaz
            if (kitap is not null)
                throw new InvalidOperationException("İlk önce kitabı siliniz.");
            _dbContext.Authors.Remove(temp);
            _dbContext.SaveChanges();
            //TODO: Model kullanmadın ileride uygun görürsen refactor edersin.
            //TODO: Aynı şekilde Validator'de kullanmadım.
        }
    }
}

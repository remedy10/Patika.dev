using webAPI.DBOperations;
using webAPI.Entities;

namespace webAPI.Application.UserOperations.Commands.CreateUser
{
    public class CreateUserCommand
    {
        public CreateUserModel MyModel { get; set; }
        private readonly IBookStoreDbContext _bookStoreDbContext;

        public CreateUserCommand(IBookStoreDbContext bookStoreDbContext)
        {
            _bookStoreDbContext = bookStoreDbContext;
        }

        public void Handle()
        {
            var checkUser = _bookStoreDbContext.Users.SingleOrDefault(
                x => x.Email == MyModel.Email
            );
            if (checkUser is not null)
                throw new InvalidOperationException("User zaten var.");

            _bookStoreDbContext.Users.Add(MyModel);
            _bookStoreDbContext.SaveChanges();
        }
    }

    public class CreateUserModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public static implicit operator User(CreateUserModel model) =>
            new User
            {
                Name = model.Name,
                Surname = model.Surname,
                Email = model.Email,
                Password = model.Password
            };
    }
}

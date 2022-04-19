using webAPI.DBOperations;
using webAPI.TokenOperations;
using webAPI.TokenOperations.Models;

namespace webAPI.Application.UserOperations.Commands.CreateToken
{
    public class CreateTokenCommand
    {
        public CreateTokenModel MyModel { get; set; }
        private readonly IBookStoreDbContext _bookStoreDbContext;
        private readonly IConfiguration _conf;

        public CreateTokenCommand(IBookStoreDbContext bookStoreDbContext, IConfiguration conf)
        {
            _bookStoreDbContext = bookStoreDbContext;
            _conf = conf;
        }

        public Token Handle()
        {
            var userExist = _bookStoreDbContext.Users.FirstOrDefault(
                x => x.Email == MyModel.Email && x.Password == MyModel.Password
            );
            if (userExist is null)
                throw new InvalidOperationException("Email veya Sifre yanlis ");
            TokenHandler tokenHandler = new(_conf);
            Token token = tokenHandler.CreateAccessToken(userExist);
            userExist.RefreshToken = token.RefreshToken;
            userExist.RefreshTokenExpireDate = token.Expiration.AddMinutes(3);
            _bookStoreDbContext.SaveChanges();
            return token;
        }
    }

    public class CreateTokenModel
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}

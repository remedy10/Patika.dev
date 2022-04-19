using webAPI.DBOperations;
using webAPI.TokenOperations;
using webAPI.TokenOperations.Models;

namespace webAPI.Application.UserOperations.Commands.RefreshToken
{
    public class RefreshTokenCommand
    {
        public string RefreshToken { get; set; }
        private readonly IBookStoreDbContext _bookStoreDbContext;
        private readonly IConfiguration _conf;

        public RefreshTokenCommand(IBookStoreDbContext bookStoreDbContext, IConfiguration conf)
        {
            _bookStoreDbContext = bookStoreDbContext;
            _conf = conf;
        }

        public Token Handle()
        {
            var userExist = _bookStoreDbContext.Users.FirstOrDefault(
                x => x.RefreshToken == RefreshToken && x.RefreshTokenExpireDate > DateTime.Now
            );
            if (userExist is null)
                throw new InvalidOperationException("Token süresi dolmus tekrar giris yapiniz");
            TokenHandler tokenHandler = new(_conf);
            Token token = tokenHandler.CreateAccessToken(userExist);
            userExist.RefreshToken = token.RefreshToken;
            userExist.RefreshTokenExpireDate = token.Expiration.AddMinutes(3);
            _bookStoreDbContext.SaveChanges();
            return token;
        }
    }
}

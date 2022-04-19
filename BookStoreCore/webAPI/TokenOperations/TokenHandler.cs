using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using webAPI.Entities;
using webAPI.TokenOperations.Models;

namespace webAPI.TokenOperations
{
    public class TokenHandler
    {
        private readonly IConfiguration _config;

        public TokenHandler(IConfiguration config)
        {
            _config = config;
        }

        public Token CreateAccessToken(User user)
        {
            Token model = new();
            SymmetricSecurityKey key = new(Encoding.UTF8.GetBytes(_config["Token:SecurityKey"]));
            SigningCredentials credentials = new(key, SecurityAlgorithms.HmacSha256);
            model.Expiration = DateTime.Now.AddMinutes(2); //5dklık accesstoken yarat
            JwtSecurityToken securtiyToken =
                new(
                    issuer: _config["Token:Issuer"],
                    audience: _config["Token:Audience"], //bunlar jsondan
                    expires: model.Expiration, //bitiş süresi
                    notBefore: DateTime.Now, //ne zaman kullanmaya başlayağın
                    signingCredentials: credentials // şifrelediğimiz key
                );
            JwtSecurityTokenHandler tokenHandler = new();
            //token yaratma işi
            model.AccessToken = tokenHandler.WriteToken(securtiyToken);
            model.RefreshToken = CreateRefreshToken();
            return model;
        }

        //! Token Üretme ve RefreshToken yaratma işlerini yaptık.
        public string CreateRefreshToken()
        {
            return Guid.NewGuid().ToString();
        }
    }
}

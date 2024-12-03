using BaseApi.Application.Dtos.Account;
using BaseApi.Shared.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BaseApi.Application.Services
{
    public class TokenService(IOptions<JwtSettings> jwtSettings)
    {
        private readonly JwtSettings _jwtSettings = jwtSettings.Value;

        public string GerarToken(UserDto user)
        {

            var key = Encoding.ASCII.GetBytes(_jwtSettings.SecretKey);
            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature);

            var handler = new JwtSecurityTokenHandler();
            var token = handler.CreateToken(
                new SecurityTokenDescriptor
                {
                    Subject = GenerateClaims(user),
                    SigningCredentials = credentials,
                    Expires = DateTime.UtcNow.AddMinutes(_jwtSettings.ExpirationMinutes)
                });

            return handler.WriteToken(token);
        }

        private static ClaimsIdentity GenerateClaims(UserDto user)
        {
            var ci = new ClaimsIdentity();

            ci.AddClaim(new Claim(ClaimTypes.Name, user.Email));
            ci.AddClaim(new Claim("Uuid", user.Uuid.ToString()));
            ci.AddClaim(new Claim("Name", user.Name));
            ci.AddClaim(new Claim("Email", user.Email));

            return ci;
        }
    }
}

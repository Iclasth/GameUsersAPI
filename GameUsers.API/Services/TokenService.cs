using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using GameUsers.API.Models;
using Microsoft.IdentityModel.Tokens;

namespace GameUsers.API.Services
{
    public class TokenService
    {
        private readonly IConfiguration _config;
        public TokenService(IConfiguration config) => _config = config;

        public string CreateToken (ApplicationUser user)
        {
            var jwtConfig = _config.GetSection("Jwt");

            var key = new SymmetricSecurityKey
            (
                Encoding.UTF8.GetBytes(jwtConfig["Key"]!)
            );

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.Id),
                new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName ?? ""),
                new Claim("displayName", user.DisplayName ?? "")
            };

            var token = new JwtSecurityToken
                (
                    issuer: jwtConfig["Issuer"],
                    audience: jwtConfig["Audience"],
                    claims: claims,
                    expires: DateTime.UtcNow.AddMinutes(
                        double.Parse(jwtConfig["ExpiresMinutes"] ?? "60")

                    ),
                    signingCredentials: creds
                );

            return new JwtSecurityTokenHandler().WriteToken(token);

        }
    }
}

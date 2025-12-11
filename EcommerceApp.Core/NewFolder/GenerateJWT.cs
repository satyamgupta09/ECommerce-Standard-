using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ECommerce_Standard_.EcommerceApp.Core.NewFolder
{
    public class GenerateJWT
    {
            private readonly string _key;

            public JwtHelper(IConfiguration configuration)
            {
                _key = configuration["Jwt:Key"];
            }

            public string GenerateToken(int userId, string email)
            {
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_key));
                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var claims = new[]
                {
            new Claim("userId", userId.ToString()),
            new Claim("email", email)
        };

                var token = new JwtSecurityToken(
                    claims: claims,
                    expires: DateTime.UtcNow.AddDays(7),
                    signingCredentials: creds);

                return new JwtSecurityTokenHandler().WriteToken(token);
 
    }
}

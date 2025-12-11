using Azure.Core;
using ECommerce_Standard_.EcommerceApp.Core.NewFolder;
using ECommerce_Standard_.EcommerveApp.API.Respositeries.Interfaces;
using Microsoft.AspNetCore.Http.HttpResults;

namespace ECommerce_Standard_.EcommerveApp.API.Respositeries.Implmentation
{
    public class UserRepository:IUserRespository
    {
        public async Task<IAsyncResult> Login(string email, string password)
        {
            var user = await GetUserDetails(email);
            if(user == null)
            {
                return Unauthorized("Invalid credentials");
            }

            if (!PasswordHasher.Verify(request.Password, user.PasswordHash))
                return Unauthorized("Invalid password");

            var token = _jwt.GenerateJWT(email, password);

            return Ok(new
            {
                token = token,
                user = new
                {
                    email = email,
                }
            });
        }
    }
}

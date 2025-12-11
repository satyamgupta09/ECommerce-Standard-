using Microsoft.AspNetCore.Mvc;

namespace ECommerce_Standard_.EcommerceAppAPI.Services.Interfaces
{
    public interface IUserService
    {
        public Task<IAsyncResult> Login(string email, string password);
        public Task<IAsyncResult> Register(string email, string password, string fname, string lname);
        public Task<IActionResult> GetUserDetails(int userId);
    }
}

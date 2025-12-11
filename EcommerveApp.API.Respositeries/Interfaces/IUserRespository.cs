using Microsoft.AspNetCore.Mvc;

namespace ECommerce_Standard_.EcommerveApp.API.Respositeries.Interfaces
{
    public interface IUserRespository
    {
        public Task<IAsyncResult> Login(string email, string password);
        public Task<IAsyncResult> Register(string email, string password, string fname, string lname);
        public Task<IActionResult> GetUserDetails(int email);
    }
}

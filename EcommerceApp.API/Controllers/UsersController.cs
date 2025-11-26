using Microsoft.AspNetCore.Mvc;

namespace ECommerce_Standard_.EcommerceApp.API.Controllers
{
    public class UsersController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

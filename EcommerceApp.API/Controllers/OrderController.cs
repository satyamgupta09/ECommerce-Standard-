using Microsoft.AspNetCore.Mvc;

namespace ECommerce_Standard_.EcommerceApp.API.Controllers
{
    public class OrderController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

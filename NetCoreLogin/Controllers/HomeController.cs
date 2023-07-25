using Microsoft.AspNetCore.Mvc;

namespace NetCoreLogin.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (!User.Identity.IsAuthenticated)
            {
                RedirectToAction("Login", "Login");
            }
            return View();


        }
    }
}

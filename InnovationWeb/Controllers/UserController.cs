using Microsoft.AspNetCore.Mvc;

namespace InnovationWeb.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

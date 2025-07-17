using Microsoft.AspNetCore.Mvc;

namespace InnovationWeb.Controllers
{
    public class TeamController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;

namespace InnovationWeb.Controllers
{
    public class ScoreController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

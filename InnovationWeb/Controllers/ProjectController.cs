using Microsoft.AspNetCore.Mvc;

namespace InnovationWeb.Controllers
{
    public class ProjectController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

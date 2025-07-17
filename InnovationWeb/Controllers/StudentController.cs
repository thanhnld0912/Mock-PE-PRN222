using Microsoft.AspNetCore.Mvc;

namespace InnovationWeb.Controllers
{
    public class StudentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

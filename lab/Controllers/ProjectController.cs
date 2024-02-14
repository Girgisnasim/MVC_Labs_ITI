using Microsoft.AspNetCore.Mvc;

namespace lab.Controllers
{
    public class ProjectController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

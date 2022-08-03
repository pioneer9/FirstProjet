using Microsoft.AspNetCore.Mvc;

namespace FirstProjet.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

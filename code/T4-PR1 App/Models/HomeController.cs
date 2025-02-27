using Microsoft.AspNetCore.Mvc;

namespace T4_PR1_App.Models
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

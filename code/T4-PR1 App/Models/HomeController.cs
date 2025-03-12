using Microsoft.AspNetCore.Mvc;

//Classe creada per defecte
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

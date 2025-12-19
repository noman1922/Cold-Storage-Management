using Microsoft.AspNetCore.Mvc;

namespace ColdStorageManagement.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
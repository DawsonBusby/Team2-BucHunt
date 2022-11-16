using Microsoft.AspNetCore.Mvc;

namespace ETSUBucHunt.WebApp.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

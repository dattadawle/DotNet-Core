using Microsoft.AspNetCore.Mvc;

namespace FirstCoreWebAPI.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

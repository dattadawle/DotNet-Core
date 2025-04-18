using Microsoft.AspNetCore.Mvc;

namespace StateManagement.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]

        public IActionResult Details(string Name, string Email, int? Age)
        {
            ViewBag.Name = Name;
            ViewBag.Email = Email;
            ViewBag.Age = Age;

            // set data to cookie
            Response.Cookies.Append("Name", Name);
            Response.Cookies.Append("Email", Email);
            Response.Cookies.Append("Age", Age.ToString());
            return View();
        }

        [HttpGet]
        public IActionResult Edit()
        {

            // Read or get cookie data

             ViewBag.Name = Request.Cookies["Name"];
            ViewBag.Email= Request.Cookies["email"];
            ViewBag.Age = Request.Cookies["Age"];
            return View();
        }
    }
}

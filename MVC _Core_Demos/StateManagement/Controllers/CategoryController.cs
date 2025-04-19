using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Text.Json;
using System.Xml.Linq;

namespace StateManagement.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            #region session
            HttpContext.Session.SetString("name", "Sampada");
            Customer customer = new Customer()
            {
                Name = "Sampada",
                Email = "sampada@gmail.com",
                Age = 21
            };

            var customer1 = JsonSerializer.Serialize(customer);

            HttpContext.Session.SetString("customer", customer1);

            #endregion

            #region TempData


            TempData["name"] = "Sampada Dhopare";

            Customer c = new Customer()
            {
                Name = "sampu",
                Email = "sampu@gmail.com",
                Age = 21
            };

            TempData["user"] = c;

            #endregion
            return View();
        }

        [HttpGet]

        public IActionResult Details(string Name, string Email, int? Age)
        {
            #region hidden , Query String and Cookie
            /*  ViewBag.Name = Name;
              ViewBag.Email = Email;
              ViewBag.Age = Age;

              // set data to cookie
              Response.Cookies.Append("Name", Name);
              Response.Cookies.Append("Email", Email, new CookieOptions()
              {
                  Expires = DateTime.Now.AddSeconds(10)

              });
              Response.Cookies.Append("Age", Age.ToString());

              Customer c = new Customer()
              {
                  Name = Name,
                  Email = Email,
                  Age= Age ?? 0
              };

              var customer= JsonSerializer.Serialize(c);

              Response.Cookies.Append("customer" , customer);*/

            #endregion
            #region ViewBag , View Data
            ViewData["name"] = Name;
            ViewBag.Email = Email;

            #endregion
           
            return View();
        }

        [HttpGet]
        public IActionResult Edit()
        {

            #region hidden , Query String and Cookie
            /*
                        // Read or get cookie data

                         ViewBag.Name = Request.Cookies["Name"];
                        ViewBag.Email= Request.Cookies["email"];
                        ViewBag.Age = Request.Cookies["Age"];

                        var customer = Request.Cookies["customer"];

                        Customer customer1=JsonSerializer.Deserialize<Customer>(customer);
                        ViewBag.customer= customer1;*/

            #endregion
            return View();



        }
    }
}

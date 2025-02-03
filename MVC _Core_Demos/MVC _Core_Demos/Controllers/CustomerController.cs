using Microsoft.AspNetCore.Mvc;
using MVC__Core_Demos.Models;

namespace MVC__Core_Demos.Controllers
{
    public class CustomerController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]

        public IActionResult Details()
        {
            Customer c = new Customer()
            {
                id=1,
                FirstName="Datta",
                LastName="Dawle"
            };
            return View(c);
        }
        public IActionResult Create()
        {
            //return View();
            return View("CreateNew");
        }

        [HttpGet("customer/detailsbyname/{name}")]
        //url customer/detailsbyname/datta
        public IActionResult DetailsByName(string name)
        {
            return View("DetailsByName",name);
            
        }

        // we do not use this way for dynamic partial view
        //  In mvc Core we have View Component
       /* [HttpGet]
        public PartialViewResult DynamicPartialView()
        {

            Customer c = new Customer()
            {
                id = 1,
                FirstName = "Datta",
                LastName = "Dawle"
            };
            return PartialView("_PartialView2");
        }*/

        // using view Component

    }
}

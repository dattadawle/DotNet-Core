using Microsoft.AspNetCore.Mvc;

namespace MVC__Core_Demos.Models.ViewComponents
{
    public class FirstViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke(int? id) // we need to write Invoke or InvokeAsinc method name here
        {
            //any logic to retrive data either database or from api or from anywhere
            //Customer customer = new Customer()
            List<Customer> customers= new List<Customer>() { 
            new Customer
            {
                id = 1,
                FirstName = "Datta",
                LastName = "Dawle"
            },
            new Customer()
            {
                id = 2,
                FirstName = "Prasad",
                LastName = "Dawle"
            },
              new Customer()
            {
                id = 3,
                FirstName = "Ajit",
                LastName = "Reddy"
            }
            };
            return View("First", customers.FirstOrDefault(c=>c.id==id));
        }
    }
}

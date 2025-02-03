using Microsoft.AspNetCore.Mvc;
using System.Text.Json;


namespace MVC__Core_Demos.Models.ViewComponents
{
    public class UsersViewComponent : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            // fetch all users 
            List<User> users = new List<User>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/users");

            HttpResponseMessage responce = client.GetAsync("").Result;

            string json=responce.Content.ReadAsStringAsync().Result;

           users= JsonSerializer.Deserialize<List<User>>(json);

            return View("UserView",users);  
        }
    }
}

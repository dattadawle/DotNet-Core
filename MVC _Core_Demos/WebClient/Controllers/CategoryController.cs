using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace WebClient.Controllers
{
    public class CategoryController : Controller
    {

        IConfiguration _configuration;
        string _apiUrl;
        public CategoryController(IConfiguration configuration)
        {
            _configuration = configuration;
            _apiUrl= _configuration.GetSection("Apiurl").Value;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Category> categories = new List<Category>();
            //api call
            using (HttpClient client = new HttpClient())
                {
                
                client.BaseAddress = new Uri(_apiUrl);
               // client.BaseAddress = new Uri("https://localhost:7223/api/");

                HttpResponseMessage response = client.GetAsync("category").Result;

                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    var options = new JsonSerializerOptions()
                    {
                        PropertyNameCaseInsensitive = true,
                    };
                    categories = JsonSerializer.Deserialize<List<Category>>(result,options);
                }
                return View(categories);
            }
           
        }


        [HttpGet]
       public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                using (HttpClient client = new HttpClient())
                {
                    client.BaseAddress = new Uri(_apiUrl);
                    //client.DefaultRequestHeaders.Add("content-type", "application/json");
                    string jsonRequest= JsonSerializer.Serialize(category);
                    HttpResponseMessage response = client.PostAsync("category", new StringContent(jsonRequest,Encoding.UTF8,"application/json")).Result;
                    if (response.IsSuccessStatusCode)
                    {
                        return RedirectToAction("Index");   
                    }

                }
            }
            return View(category);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            Category category = null;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(_apiUrl);
                HttpResponseMessage response = client.GetAsync($"category/{id}").Result;
                if (response.IsSuccessStatusCode)
                {
                    var options = new JsonSerializerOptions()
                    {
                        PropertyNameCaseInsensitive = true,
                    };

                    string result= response.Content.ReadAsStringAsync().Result;
                   category= JsonSerializer.Deserialize<Category>(result,options);
                }
            }
            return View(category);
        }

        [HttpGet]
        public IActionResult Edit(int id)
            {
            Category category = null;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress= new Uri(_apiUrl);
                HttpResponseMessage response = client.GetAsync($"category/{id}").Result;
                if (response.IsSuccessStatusCode)
                {
                    var result= response.Content.ReadAsStringAsync().Result;
                    

                    category= JsonSerializer.Deserialize<Category>(result,new JsonSerializerOptions() { PropertyNameCaseInsensitive =true});
                }
              
            }
               return View(category);
            }

        [HttpPost]

        public IActionResult Edit(Category category)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(_apiUrl);
                var result= JsonSerializer.Serialize<Category>(category);
               HttpResponseMessage request = client.PutAsync($"category/{category.Id}", new StringContent(result, Encoding.UTF8, "application/json")).Result;

                if (request.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

            }

            return View("Index");
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            Category category = null;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(_apiUrl);
                HttpResponseMessage response = client.GetAsync($"category/{id}").Result;
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;


                    category = JsonSerializer.Deserialize<Category>(result, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                }

            }
            return View(category);
        }

        [HttpDelete]
        [ActionName("Delete")]
        public IActionResult Deletecat(Category category)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(_apiUrl);
                bool IsDeleted = client.DeleteAsync($"category/{category}").IsCompleted;
                if (IsDeleted)
                {
                    return RedirectToAction("Index");
                };

                return RedirectToAction("Index");
            }
        }

    }
}

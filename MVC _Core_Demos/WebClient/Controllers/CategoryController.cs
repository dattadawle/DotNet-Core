using ClientService.IHttpService.Contract;
using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace WebClient.Controllers
{
    public class CategoryController : Controller
    {
        IHttpClientService _clientService;
        IConfiguration _configuration;
        string _apiUrl;
        public CategoryController(IConfiguration configuration , IHttpClientService clientService)
        {
            _configuration = configuration;
            _apiUrl= _configuration.GetSection("Apiurl").Value;
            _clientService = clientService;
        }

        [HttpGet]
        public async Task <IActionResult> Index()
        {
            //List<Category> categories = new List<Category>();

            /*  //api call
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
                      categories = JsonSerializer.Deserialize<List<Category>>(result, options);
                  }
                  return View(categories);
              }*/
            List<Category> categories = new List<Category>();

            categories = await _clientService.GetTAsync<List<Category>>("category");

            return View(categories);
        }


        [HttpGet]
       public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            /* if (ModelState.IsValid)
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
             }*/

            if (ModelState.IsValid)
            {
                await _clientService.PostAsync<Category>("category", category);
                return RedirectToAction("Index");
            }

            ModelState.AddModelError("", "Error with adding categories");
            return View(category);
        }

        [HttpGet]
        public IActionResult Details(int id)
        {
            /* Category category = null;
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
             }*/
          Category category=  _clientService.GetTAsync<Category>($"category/{id}").Result;

            return View(category);
        }

        [HttpGet]
        public  async Task <IActionResult>Edit(int? id)
            {
            /*  Category category = null;
              using (HttpClient client = new HttpClient())
              {
                  client.BaseAddress= new Uri(_apiUrl);
                  HttpResponseMessage response = client.GetAsync($"category/{id}").Result;
                  if (response.IsSuccessStatusCode)
                  {
                      var result= response.Content.ReadAsStringAsync().Result;


                      category= JsonSerializer.Deserialize<Category>(result,new JsonSerializerOptions() { PropertyNameCaseInsensitive =true});
                  }*/
            Category category = await _clientService.GetTAsync<Category>($"category/{id}");

               return View(category);
            }

        [HttpPost]

        public async Task<IActionResult>Edit(Category category)
        {
            /*using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(_apiUrl);
                var result = JsonSerializer.Serialize<Category>(category);
                HttpResponseMessage request = client.PutAsync($"category/{category.Id}", new StringContent(result, Encoding.UTF8, "application/json")).Result;

                if (request.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }

            }*/
            if (ModelState.IsValid)
            {
               var response= await _clientService.PutAsync<Category>($"category/{category.Id}", category);

                return RedirectToAction("Index");
            }
           return View(category);
        }

        [HttpGet]
        public IActionResult Delete(int id)
        {
            /*Category category = null;
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(_apiUrl);
                HttpResponseMessage response = client.GetAsync($"category/{id}").Result;
                if (response.IsSuccessStatusCode)
                {
                    var result = response.Content.ReadAsStringAsync().Result;


                    category = JsonSerializer.Deserialize<Category>(result, new JsonSerializerOptions() { PropertyNameCaseInsensitive = true });
                }

            }*/
            Category category = _clientService.GetTAsync<Category>($"category/{id}").Result;
            return View(category);
        }

        [HttpPost]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteCat(int id)
        {
            /* using (HttpClient client = new HttpClient())
             {
                 client.BaseAddress = new Uri(_apiUrl);
                 bool IsDeleted = client.DeleteAsync($"category/{category}").IsCompleted;
                 if (IsDeleted)
                 {
                     return RedirectToAction("Index");
                 };

                 return RedirectToAction("Index");
             }*/
           // Category category = _clientService.GetTAsync<Category>($"category/{id}").Result;
            await _clientService.DeleteAsync<Category>($"category/{id}");
            return RedirectToAction("Index");
        }

        //mane is a disgusting despo
    }
}

using ClientService.IHttpService.Contract;
using Microsoft.AspNetCore.Mvc;

public class CategoryController : Controller
{
    #region old code

    //IConfiguration _configuration;
    //string _apiUrl;

    //public CategoryController(IConfiguration configuration)
    //{
    //    _configuration = configuration;
    //    _apiUrl = _configuration.GetSection("apiUrl").Value;
    //}

    #endregion old code

    private readonly IHttpClientService _clientService;

    public CategoryController(IHttpClientService clientService)
    {
        _clientService = clientService;
    }

    [HttpGet]
    public async Task<IActionResult> Index()
    {
        List<Category> categories = new List<Category>();
        categories =
           await _clientService.GettAsync<List<Category>>("category");

        #region using direct HttpClient class

        //// api call
        //using (HttpClient client = new HttpClient())
        //{
        //    client.BaseAddress = new Uri(_apiUrl);
        //    // client.BaseAddress = new Uri("https://localhost:7018/api/");

        //    //var token = HttpContext.Session.GetString("token");
        //    //client.DefaultRequestHeaders.Add("Authorization", $"Bearer {token}");

        //    HttpResponseMessage response = client.GetAsync("category").Result;

        //    if (response.IsSuccessStatusCode)
        //    {
        //        string result = response.Content.ReadAsStringAsync().Result;

        //        //var options = new JsonSerializerOptions()
        //        //{
        //        //    PropertyNameCaseInsensitive = true
        //        //};

        //        //categories = JsonSerializer.Deserialize<List<Category>>(result, options);
        //        categories = JsonSerializer.Deserialize<List<Category>>(result);
        //    }
        //}
        #endregion using direct HttpClient class


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
        if (ModelState.IsValid)
        {
            var response = await _clientService.PostAsync<Category>("category", category);

            return RedirectToAction("Index");

            #region using direct HttpClient class
            //// api call
            //using (HttpClient client = new HttpClient())
            //{
            //    client.BaseAddress = new Uri(_apiUrl);
            //    string jsonRequest = JsonSerializer.Serialize(category);
            //    HttpResponseMessage response =
            //        client.PostAsync("category", 
            //        new StringContent(jsonRequest,Encoding.UTF8, "application/json"))
            //        .Result;

            //    if (response.IsSuccessStatusCode)
            //    {
            //        return RedirectToAction("Index");
            //    }
            //}
            #endregion using direct HttpClient class
        }

        ModelState.AddModelError("", "Error in adding category");
        return View(category);
    }

    [HttpGet]
    public async Task<IActionResult> Edit(int? id)
    {
        Category category = await _clientService.GettAsync<Category>($"category/{id}");

        return View(category);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Category category)
    {
        if (ModelState.IsValid)
        {
            var response = await _clientService.PutAsync<Category>($"category/{category.Id}", category);
            return RedirectToAction("Index");
        }

        return View(category);
    }

}
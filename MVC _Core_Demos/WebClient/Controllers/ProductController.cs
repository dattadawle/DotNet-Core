using ClientService.IHttpService.Contract;
using Microsoft.AspNetCore.Mvc;

namespace WebClient.Controllers
{
    public class ProductController : Controller
    {
        IHttpClientService _clientService;
        IConfiguration _configuration;
        string _apiUrl;
        public ProductController(IConfiguration configuration, IHttpClientService clientService)
        {
            _configuration = configuration;
            _apiUrl = _configuration.GetSection("Apiurl").Value;
            _clientService = clientService;
        }

        [HttpGet]
        public async Task <IActionResult> Index()
        {
          var categories=  await _clientService.GetTAsync<List<Product>>("category");
            return View();
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public Task<IActionResult> Create(ProductModel product)
        {
            if (ModelState.IsValid)
            {
                _clientService.PostAsync<Product>("category",product);
            }
            return null;
        }

        [HttpGet]
        public async Task <IActionResult> Edit(int id)
        {
            if (id>0)
            {
                var prod = await _clientService.GetTAsync<ProductModel>($"product/{id}");
                return View(prod);
            }
           return RedirectToAction("Index");
        }
        [HttpPost]
        public async Task <IActionResult>Edit(ProductModel productModel)
        {
            if (ModelState.IsValid)
            {
                _clientService.PutAsync<Product>("product", productModel);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (id>0)
            {
              var prod= await   _clientService.GetTAsync<ProductModel>($"product/{id}");
                return View(prod);
            }
            return RedirectToAction("Index");
        }
        [HttpDelete]
        [ActionName("Delete")]
        public async Task<IActionResult> DeleteProd(int id)
        {
            if (id>0)
            {
                //var prod = await _clientService.GetTAsync<ProductModel>($"product/{id}");
                await _clientService.DeleteAsync<Product>($"product/{id}");
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
     
}

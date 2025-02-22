using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        public readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            this._productService = productService;
        }

        [HttpGet]
        public async Task <IActionResult> Index()
        {
            var prod= await _productService.GetAllAsync();
            return Ok(prod);
        }
        [HttpPost]

        public async Task<IActionResult> Create(ProductModel productModel)
        {
           if(ModelState.IsValid)
            {
                await _productService.CreateAsync(productModel);
                return Ok(productModel);
            }
           else
            return BadRequest();
        }

        [HttpPut]

        public async Task < IActionResult> Edit([FromRoute]int id,ProductModel productModel) 
            {
              if(id>0)
            {
                if (id==productModel.Id)
                {
                    if (!ModelState.IsValid)
                    {
                        await _productService.UpdateAsync(productModel);
                        return Ok();
                    }
                }
                  return BadRequest();
            }
              return BadRequest();
            }

        [HttpDelete]
        public async  Task<ActionResult> Delete([FromRoute]int id)
        {
            if (id>0)
            {
            var product= await _productService.GetByIdAsync(id);
                _productService.DeleteAsync(product);
            }
            return BadRequest();
        }
    }
}

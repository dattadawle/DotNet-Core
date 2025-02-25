using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Services.Interfaces;

namespace API.Controllers
{
    [Route("api/v{version:ApiVersion}/Category")]
    [ApiController]
    [ApiVersion("2.0")]
    public class CategoryV2Controller : Controller
    {
        private readonly ICategoryService _categoryService;
        private readonly IMemoryCache _memoryCache;
        public CategoryV2Controller(ICategoryService categoryService, IMemoryCache memoryCache)
        {
            _categoryService = categoryService;
            _memoryCache = memoryCache;
        }

        [HttpGet]
       [Route("GetCategories")]
        public async Task<IActionResult> Get()
        {

            //creating cache
            IEnumerable<CategoryModel> categories = _memoryCache.Get("categories") as List<CategoryModel>;
            if (categories == null)
            {
                categories = await _categoryService.GetAllAsync();
                _memoryCache.Set("categories", categories);
            }
            return Ok(categories.Take(2)); // will take only top 2 records
        }

    }
}

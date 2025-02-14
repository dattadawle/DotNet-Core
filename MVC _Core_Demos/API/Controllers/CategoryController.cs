using Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]      
        public async Task<IActionResult> Get()
        {
            var categories = await _categoryService.GetAllAsync();
            return Ok(categories);
        }

        [HttpGet]
        [Route("{id:int}")]

        public async Task<IActionResult> GetById(int id)
        {
            if (id > 0)
            {
                var category = await _categoryService.GetByIdAsync(id);
                return Ok(category);
            }
            return BadRequest();
        }

        [HttpPost]
        public async  Task<IActionResult> Create(CategoryModel category)
        {
           
            try
            {
                if (ModelState.IsValid)
                {
                    await _categoryService.CreateAsync(category);
                    return Ok(category);
                }
            }
            catch (Exception)
            {
                return BadRequest();
            }
          return BadRequest();
        }

        [HttpPut]
        [Route("{id:int}")] // this value comes from route
        public async Task <IActionResult> Update([FromRoute]int id ,CategoryModel category)
         
        {
              if(id > 0)
              {
                  if(id==category.Id)
                  {

                      if (ModelState.IsValid)
                      {
                       await  _categoryService.UpdateAsync(category);
                          return Ok(category);
                      }
                      return BadRequest();
                  }
                  return BadRequest();
              }
              return BadRequest();
          }

        [HttpDelete]
      
          public async Task< IActionResult> Delete(int id)
          {
            if (id > 0)
            {
                var category= await _categoryService.GetByIdAsync(id) ;
              if (category != null)
              {
                  
                      _categoryService.DeleteAsync(id);
                      return Ok();
              }
              else
                {
                    return NotFound();
                }
                  
            }
              return BadRequest();
          }

        [HttpGet]

        [Route("api/category/productByCategoryName")]// ths comes from query
        public IActionResult GetProductByName([FromQuery]string name)
        {
            string categoryName = name;

            return Ok(categoryName);
        }
    }
}

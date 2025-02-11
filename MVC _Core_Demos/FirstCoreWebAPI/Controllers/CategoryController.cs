using FirstCoreWebAPI.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using System.Reflection.Metadata.Ecma335;

namespace FirstCoreWebAPI.Controllers
{
    [Route("api/[controller]")]  //. Action methods on controllers annotated with ApiControllerAttribute must be attribute routed.'

    [ApiController]
    public class CategoryController : Controller
    {
        ApplicationDbContext _context;
        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        //  public IEnumerable<Category> getAll()

        [ProducesResponseType(200, Type = typeof(IEnumerable<Category>))]

        public IActionResult GetAll()
        {
            /* var categories = new List<Category>()
             {
                 new Category(){Id=1,Name="Cat 1", Description="cat 1 description"},
                  new Category(){Id=1,Name="Cat 2", Description="cat 2 description"},
                   new Category(){Id=1,Name="Cat 3", Description="cat 3 description"}
             };*/

            var categories = _context.categories.ToList();
            return Ok(categories);
        }

        [HttpGet("{id:int}")]
        [ProducesErrorResponseType(typeof(BadRequest))]
        [ProducesResponseType(201, Type = typeof(Category))]
       
        public IActionResult GetById(int id)
        {
            if (id > 0)
            {

                //Category category = new Category() { Id = 1, Name = "Cat 3", Description = "cat 3 description" };

                Category category = _context.categories.Find(id);
                if (category != null) {
                    
                        return Ok(category);
                    }
                else
                {
                    return NotFound();// 404
                }
            }
            return BadRequest();
        }
       [HttpPost]
        [ProducesErrorResponseType(typeof(BadRequest))]
        [ProducesResponseType(201, Type = typeof(Category))]
        public IActionResult Create(Category category)
        {
            
            if (ModelState.IsValid)
            {
                _context.categories.Add(category);
                _context.SaveChanges();
                return CreatedAtAction("GetAll", category);
            }

            return BadRequest();
        }

        [HttpPut("{id:int}")]
        [ProducesErrorResponseType(typeof(BadRequest))]
        [ProducesResponseType(200, Type = typeof(Category))]
        public IActionResult Update(int id ,Category category)
        {
            if (id >0)
            {
                if (id == category.Id)
                {
                    if (ModelState.IsValid)
                    { 
                        //update category
                        _context.categories.Attach(category);
                        _context.Entry(category).State= EntityState.Modified;
                        _context.SaveChanges();
                        return Ok( category);
                    }
                    return BadRequest();
                }
                return BadRequest();
            }
            return BadRequest();
        }


        [HttpDelete("{id:int}")]
        [ProducesErrorResponseType(typeof(BadRequest))]
        [ProducesResponseType(200, Type = typeof(Category))]

        public IActionResult Delete(int id)
        {
            if (id >0)
            {
                Category category = _context.categories.Find(id);
               if (category != null)
                {
                    //delete category
                    _context.categories.Remove(category);       
                    _context.SaveChanges(); 
                    return Ok();
                }
               return NotFound();
            }
            return BadRequest();
        }

    }
}

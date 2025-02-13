using Data;
using Data.Entities;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Implementations
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _context;

        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Create(Category category)
        {
           _context.categories.Add(category);
           _context.SaveChanges();
        }

        public void Delete(int id)
        {
            Category category = _context.categories.Find(id);

            _context.categories.Remove(category);

            _context.SaveChanges(); 
        }

        public async Task<IEnumerable<Category>> GetAllAsync()

        {
            return await _context.categories.ToListAsync();    
        }

        public void Update(Category category)
        {
           _context.categories.Attach(category);
            _context.Entry(category).State= EntityState.Modified;
            _context.SaveChanges();

        }

       public   Category GetById(int id)
        {
            return _context.categories.Find(id);
        }

       
    }
}

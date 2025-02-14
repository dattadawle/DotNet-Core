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

        public async Task CreateAsync(Category category)
        {
           _context.categories.Add(category);
           _context.SaveChanges();
        }

        public async Task DeleteAsync(int id)
        {
            Category category = _context.categories.Find(id);

            _context.categories.Remove(category);

            _context.SaveChanges(); 
        }

        public async Task<IEnumerable<Category>> GetAllAsync()

        {
            return  _context.categories.ToList(); 
        }

        public async Task UpdateAsync(Category category)
        {
         _context.categories.Attach(category);
            _context.Entry(category).State= EntityState.Modified;
             _context.SaveChanges();

        }

       public async Task<Category> GetByIdAsync(int id)
        {
            return  _context.categories.Find(id);
        }

    }
}

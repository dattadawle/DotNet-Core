using Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Interfaces;
public class ProductRepository : IProductRepository
{
    ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<List<Product>> GetAllAsync()
    {
        return await _context.products.ToListAsync(); ;
    }

    public async Task CreateAsync(Product product)
    {
        _context.products.Add(product);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        Product product=await _context.products.FindAsync(id);
        _context.products.Remove(product);
        await _context.SaveChangesAsync();
    }

    public async Task<Product> GetByIdAsync(int id)
    {
     return await _context.products.FindAsync(id);
       
    }

    public async Task UpdateAsync(Product product)
    { 
        _context.products.Attach(product);
         _context.products.Entry(product).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}

   


using Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
public class ProductRepository : IProductRepository
{
    ApplicationDbContext _context;

    public ProductRepository(ApplicationDbContext context)
    {
        _context = context;
    }
    public async Task<List<Product>> GetAllAsync()
    {
     var prooducts= _context.products.ToList();
        return prooducts;
    }

    public async Task CreateAsync(Product product)
    {
        _context.products.Add(product);
        _context.SaveChanges();
    }

    public async Task DeleteAsync(int id)
    {
        Product product=_context.products.Find(id);
        _context.products.Remove(product);
        _context.SaveChanges();
    }

    public async Task<Product> GetByIdAsync(int id)
    {
     return _context.products.Find(id);
       
    }

    public async Task UpdateAsync(Product product)
    { 
        _context.products.Attach(product);
         _context.products.Entry(product).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}

   


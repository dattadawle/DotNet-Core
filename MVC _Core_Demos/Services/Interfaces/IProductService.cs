using System.Collections.Generic;
using System.Threading.Tasks;

public interface IProductService
{
    Task<List<ProductModel>> GetAllAsync();

   
    Task CreateAsync(ProductModel product);

    Task UpdateAsync(ProductModel product);
    Task DeleteAsync(ProductModel product);
    Task<ProductModel> GetByIdAsync(int  id);
}
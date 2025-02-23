
using AutoMapper;
using Infrastructure.Interfaces;
using Data.Entities;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;
   private readonly IMapper _mapper;

    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        _productRepository = productRepository;
        _mapper = mapper;
        _mapper = mapper;
    }

    public async Task CreateAsync(ProductModel product)
    {
        var prod = _mapper.Map<Product>(product);

        await _productRepository.CreateAsync(prod);

      
    }

    public async Task DeleteAsync(ProductModel product)
    {
        await _productRepository.DeleteAsync(product.Id);
    }

    public async Task<List<ProductModel>> GetAllAsync()
    {
        var dbProducts = await _productRepository.GetAllAsync();

        var products = _mapper.Map<List<ProductModel>>(dbProducts);

        return products;
    }

    public async Task<ProductModel> GetByIdAsync(int id)
    {
        var dbproduct = await _productRepository.GetByIdAsync(id);
        if (dbproduct != null)
        {
            return _mapper.Map<ProductModel>(dbproduct);
        }
        return null;
    }

    public async Task UpdateAsync(ProductModel productModel)
    {
        var product = _mapper.Map<Product>(productModel);
        await _productRepository.UpdateAsync(product);
    }

    
}
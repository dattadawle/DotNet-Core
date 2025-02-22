using AutoMapper;
using Data.Entities;
using Infrastructure.Interfaces;
using Services.Interfaces;
public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _cateGoryRepository;
    private readonly IMapper _mapper;
    public CategoryService(ICategoryRepository icateGoryRepository,IMapper mapper)
    {
        _cateGoryRepository = icateGoryRepository;
        _mapper = mapper;
    }



    public async Task CreateAsync(CategoryModel category)
    {
        /*Make async if it involves saving data to a database or any other I/O-bound operation. Saving data, especially in databases, is a common I/O-bound operation that benefits from being asynchronous.*/
        var cat =  _mapper.Map<Category>(category);
        await _cateGoryRepository.CreateAsync(cat);
    }

    public async Task DeleteAsync(int id)
    {
       /* Make async if it involves deleting data from a database or any other I/ O - bound operation.Deleting records from a database is another I / O - bound operation that benefits from being asynchronous.*/

        await _cateGoryRepository.DeleteAsync(id);
    }



    public async Task<IEnumerable<CategoryModel> > GetAllAsync()
    {
       // Q. why we need to make this method async
        /*1.GetAll()
        Make async if it involves querying a database or any other I/ O - bound operation.Retrieving a large set of data from a database can take time, and making the method async allows your application to handle other tasks while waiting for the database query to complete.*/
        var dbCategories= await _cateGoryRepository.GetAllAsync();
        var categories= _mapper.Map<List<CategoryModel>>(dbCategories);
        return categories;
    }
    /* public async Task<IEnumerable<ProductModel>> GetAllAsync()
        {
            var dbProducts =  _productRepository.GetAllAsync();

            var products = _mapper.Map<IEnumerable<ProductModel>>(dbProducts);

            return products;
        }*/

    public async Task<CategoryModel> GetByIdAsync(int id)
    {
        /*Make async if it involves querying a database or any other I/O-bound operation. Even though retrieving a single item is a relatively fast operation, if it involves a database query, it's still beneficial to make it async.*/
        Category dbCat = await _cateGoryRepository.GetByIdAsync(id);
        if (dbCat != null)
        {
            return _mapper.Map<CategoryModel>(dbCat);
        }
        else
            return null;
        
    }



    public async Task UpdateAsync( CategoryModel category)
    {
      /*  Make async if it involves saving or updating data in a database. Like Create(), updating data is an I / O - bound operation, and making it async ensures that your application doesn't block while waiting for the operation to complete.*/

       await _cateGoryRepository.UpdateAsync(_mapper.Map<Category>(category));  //we can map like this also
    }
}

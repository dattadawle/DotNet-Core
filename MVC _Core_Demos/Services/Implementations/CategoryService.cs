using Services.Interfaces;


using Infrastructure.Interfaces;
using AutoMapper;
using Data.Entities;
public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _cateGoryRepository;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository icateGoryRepository,IMapper mapper)
    {
        _cateGoryRepository = icateGoryRepository;
        _mapper = mapper;
    }

    public void Create(CategoryModel category)
    {
        var cat = _mapper.Map<Category>(category);
        _cateGoryRepository.Create(cat);



    }

    public void Delete(int id)
    {
      _cateGoryRepository.Delete(id);
    }

    public async Task< IEnumerable<CategoryModel> > GetAllAsync()
    {
        var dbCategories= await _cateGoryRepository.GetAllAsync();
        var categories= _mapper.Map<List<CategoryModel>>(dbCategories);
         return categories;
    }

    public CategoryModel GetById(int id)
    {
        Category dbCat = _cateGoryRepository.GetById(id);

        return _mapper.Map<CategoryModel>(dbCat);
    }

    public void Update(int id, CategoryModel category)
    {
        _cateGoryRepository.Update(_mapper.Map<Category>(category));  //we can map like this also
    }
}

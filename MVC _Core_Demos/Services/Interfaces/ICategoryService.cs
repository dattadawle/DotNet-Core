namespace Services.Interfaces
{
    public interface ICategoryService
    {
       Task< IEnumerable<CategoryModel>> GetAllAsync();

       Task<CategoryModel> GetByIdAsync(int id);
       Task CreateAsync(CategoryModel category);

       Task UpdateAsync( CategoryModel category);

        Task  DeleteAsync(int id);
    }
}

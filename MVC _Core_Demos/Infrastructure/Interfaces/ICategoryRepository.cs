using Data.Entities;

namespace Infrastructure.Interfaces
{
    public interface ICategoryRepository
    {
      Task <IEnumerable<Category>>GetAllAsync();

        Category GetById(int id);
        void Create(Category category);

        void Update(Category category);

        void Delete(int id);
    }
}

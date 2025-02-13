using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Interfaces
{
    public interface ICategoryService
    {
       Task< IEnumerable<CategoryModel>> GetAllAsync();

        CategoryModel GetById(int id);
        void Create(CategoryModel category);

        void Update(int id, CategoryModel category);

        void Delete(int id);
    }
}

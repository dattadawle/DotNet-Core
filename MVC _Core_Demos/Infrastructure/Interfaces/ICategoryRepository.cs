﻿using Data.Entities;

namespace Infrastructure.Interfaces
{
    public interface ICategoryRepository
    {
      Task <IEnumerable<Category>> GetAllAsync();

        Task<Category> GetByIdAsync(int id);
        Task CreateAsync(Category category);

        Task UpdateAsync(Category category);

        Task DeleteAsync(int id);
    }
}

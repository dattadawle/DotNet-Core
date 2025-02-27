﻿using Data.Entities;
namespace Infrastructure.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();

        Task CreateAsync(Product product);

        Task<Product> GetByIdAsync(int id);

        Task UpdateAsync(Product product);

        Task DeleteAsync(int id);

    }
}
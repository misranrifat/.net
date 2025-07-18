using System.Collections.Generic;
using System.Threading.Tasks;
using DotNetApi.Models;

namespace DotNetApi.Repositories
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(int id);
        Task<Product> CreateAsync(Product product);
        Task<Product> UpdateAsync(Product product);
        Task<bool> DeleteAsync(int id);
    }
} 
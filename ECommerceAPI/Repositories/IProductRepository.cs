using ECommerceAPI.Models;

namespace ECommerceAPI.Repositories
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAllAsync();
        Task<Product?> GetByIdAsync(int id);
        Task<bool> SaveChangesAsync();
        Task<int> CountAsync();

        void Add(Product product);

        void Update(Product product);

        void Delete(Product product);

        
    }
}
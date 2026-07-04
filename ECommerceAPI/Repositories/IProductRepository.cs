using ECommerceAPI.Models;

namespace ECommerceAPI.Repositories
{
    public interface IProductRepository
    {
        List<Product> GetAll();

        Product? GetById(int id);

        void Add(Product product);

        void Update(Product product);

        void Delete(Product product);

        bool SaveChanges();

        int Count();
    }
}
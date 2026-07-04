using ECommerceAPI.Data;
using ECommerceAPI.Models;

namespace ECommerceAPI.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        public List<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public Product? GetById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }

        public void Add(Product product)
        {
            _context.Products.Add(product);
        }

        public void Update(Product product)
        {
            // EF Core zaten entity'yi takip ediyor
        }

        public void Delete(Product product)
        {
            _context.Products.Remove(product);
        }

        public bool SaveChanges()
        {
            return _context.SaveChanges() > 0;
        }
        public int Count()
        {
            return _context.Products.Count();
        }
       
    }
}
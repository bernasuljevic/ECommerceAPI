using Microsoft.AspNetCore.Mvc;
using ECommerceAPI.Models;

namespace ECommerceAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]

    public class ProductsController : ControllerBase
    {
        private static readonly List<Product> Products = new()
            {
                new Product
                {
                    Id = 1,
                    Name = "Laptop",
                    Price = 35000,
                    Stock = 15,
                    Category = "Elektronik"
                },
                new Product
                {
                    Id = 2,
                    Name = "Mouse",
                    Price = 500,
                    Stock = 40,
                    Category = "Aksesuar"
                },
                new Product
                {
                    Id = 3,
                    Name = "Klavye",
                    Price = 1200,
                    Stock = 25,
                    Category = "Aksesuar"
                }
            
    
};

        public static List<Product> Products1 => Products;

        [HttpGet]
        public List<Product> Get()
        {
            return Products1;
        }

        [HttpGet("{id}")]
        public Product GetById(int id)
        {
            return Products1.FirstOrDefault(p => p.Id == id);
        }
        [HttpGet("count")]
        public int GetCount()
        {
            return Products1.Count;
        }

        [HttpPost]
        public Product AddProduct(Product product)
        {
            Products1.Add(product);

            return product;
        }
        [HttpDelete("{id}")]
        public string DeleteProduct(int id)
        {
            var product = Products1.FirstOrDefault(p => p.Id == id);

            if (product == null)
            {
                return "Ürün bulunamadı";
            }

            Products1.Remove(product);

            return "Ürün silindi";
        }
    }
}
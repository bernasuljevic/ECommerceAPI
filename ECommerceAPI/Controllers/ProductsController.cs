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
        new Product { Id = 1, Name = "Laptop", Price = 35000 },
        new Product { Id = 2, Name = "Mouse", Price = 500 },
        new Product { Id = 3, Name = "Klavye", Price = 1200 }
        };

        [HttpGet]
        public List<Product> Get()
        {
            return Products;
        }

        [HttpGet("{id}")]
        public Product GetById(int id)
        {
            return Products.FirstOrDefault(p => p.Id == id);
        }
        [HttpGet("count")]
        public int GetCount()
        {
            return Products.Count;
        }

        [HttpPost]
        public Product AddProduct(Product product)
        {
            Products.Add(product);

            return product;
        }
    }
}
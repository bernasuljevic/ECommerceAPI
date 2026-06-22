using Microsoft.AspNetCore.Mvc;
using ECommerceAPI.Models;

namespace ECommerceAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public List<Product> Get()
        {
            return new List<Product>
            {
                new Product
                {
                    Id = 1,
                    Name = "Laptop",
                    Price = 35000
                },
                new Product
                {
                    Id = 2,
                    Name = "Mouse",
                    Price = 500
                },
                new Product
                {
                    Id = 3,
                    Name = "Klavye",
                    Price = 1200
                }
            };
        }
    }
}
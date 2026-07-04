using ECommerceAPI.DTOs;
using ECommerceAPI.Models;
using ECommerceAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductRepository _repo;

        public ProductsController(IProductRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public List<Product> Get()
        {
            return _repo.GetAll();
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var product = _repo.GetById(id);

            if (product == null)
            {
                return NotFound("Ürün bulunamadı");
            }

            return Ok(product);
        }

        [HttpGet("count")]
        public int GetCount()
        {
            return _repo.Count();
        }

        [HttpPost]
        public IActionResult AddProduct(CreateProductDto dto)
        {
            var product = new Product
            {
                Name = dto.Name,
                Price = dto.Price,
                Stock = dto.Stock,
                Category = dto.Category
            };

            _repo.Add(product);
            _repo.SaveChanges();

            var productDto = new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Price = product.Price,
                Stock = product.Stock,
                Category = product.Category
            };

            return Ok(productDto);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _repo.GetById(id);

            if (product == null)
            {
                return NotFound("Ürün bulunamadı");
            }

            _repo.Delete(product);
            _repo.SaveChanges();

            return Ok("Ürün silindi");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateProduct(int id, UpdateProductDto dto)
        {
            var product = _repo.GetById(id);

            if (product == null)
            {
                return NotFound("Ürün bulunamadı");
            }

            product.Name = dto.Name;
            product.Price = dto.Price;
            product.Stock = dto.Stock;
            product.Category = dto.Category;

            _repo.SaveChanges();

            return Ok(product);
        }
    }
}
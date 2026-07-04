using ECommerceAPI.Data;
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
        private readonly AppDbContext _context;

        public ProductsController(
            IProductRepository repo,
            AppDbContext context)
        {
            _repo = repo;
            _context = context;
        }

        [HttpGet]
        public async Task<List<Product>> Get()
        {
            return await _repo.GetAllAsync();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _repo.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound("Ürün bulunamadı");
            }

            return Ok(product);
        }

        [HttpGet("count")]
        public async Task<int> GetCount()
        {
            return await _repo.CountAsync();
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct(CreateProductDto dto)
        {
            var product = new Product
            {
                Name = dto.Name,
                Price = dto.Price,
                Stock = dto.Stock,
                Category = dto.Category
            };

            _repo.Add(product);
            await _repo.SaveChangesAsync();

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
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var product = await _repo.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound("Ürün bulunamadı");
            }

            _repo.Delete(product);
            await _repo.SaveChangesAsync();

            return Ok("Ürün silindi");
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, UpdateProductDto dto)
        {
            var product = await _repo.GetByIdAsync(id);

            if (product == null)
            {
                return NotFound("Ürün bulunamadı");
            }

            product.Name = dto.Name;
            product.Price = dto.Price;
            product.Stock = dto.Stock;
            product.Category = dto.Category;

            await _repo.SaveChangesAsync();

            return Ok(product);
        }
        [HttpPost("transaction-test")]
        public async Task<IActionResult> TransactionTest()
        {
            using var transaction =
                await _context.Database.BeginTransactionAsync();

            try
            {
                var product1 = new Product
                {
                    Name = "Transaction Test 1",
                    Price = 100,
                    Stock = 1,
                    Category = "Test"
                };

                _context.Products.Add(product1);
                await _context.SaveChangesAsync();

                throw new Exception("Bilinçli hata oluşturuldu.");

                var product2 = new Product
                {
                    Name = "Transaction Test 2",
                    Price = 200,
                    Stock = 2,
                    Category = "Test"
                };

                _context.Products.Add(product2);
                await _context.SaveChangesAsync();

                await transaction.CommitAsync();

                return Ok();
            }
            catch
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}
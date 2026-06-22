using Microsoft.AspNetCore.Mvc;

namespace ECommerceAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        [HttpGet]
        public List<string> Get()
        {
            return new List<string>
    {
        "Laptop",
        "Mouse",
        "Klavye"
    };
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnyxCom.BusinessApi.Auth;
using System.Drawing;

namespace OnyxCom.BusinessApi.Controllers
{
    [ApiController]
    public class ProductController : ControllerBase
    {
        private static readonly string[] Colors = new[]
        {
        "Blue", "Pink", "Purple", "Orange", "Golden", "Yellow", "Red", "Crimson", "Gray"
        };

        private static readonly string[] CarName = new[]
        {
        "Honda Civic", "Honda Jazz", "Honda City", "Honda CRV", "Honda BRV"
        };

        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }

        [HttpGet()]
        [Route("")]
        public string Get()
        {
            return "Healthcheck OK.";
        }

        [HttpGet()]
        [Route("api/[controller]")]
        [ServiceFilter(typeof(ApiKeyAuthFilter))]
        public IEnumerable<Products> GetProducts()
        {
            return Enumerable.Range(1, 15).Select(index => new Products
            {
                Id = index,
                Name = CarName[index % CarName.Length],
                Color = Colors[index % Colors.Length]
            })
            .ToArray();
        }

        [HttpGet()]
        [Route("api/[controller]/{Color}")]
        [ServiceFilter(typeof(ApiKeyAuthFilter))]
        public IEnumerable<Products> GetProductsByColor(string Color)
        {
            return Enumerable.Range(1, 15).Select(index => new Products
            {
                Id = index,
                Name = CarName[index % CarName.Length],
                Color = Colors[index % Colors.Length]
            }).Where(p => p.Color.Equals(Color))
            .ToArray();
        }
    }
}
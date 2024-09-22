using API_AgroGest.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Models;
using System.Collections.Generic;
using System.Linq;

namespace API_AgroGest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly MyDbContext _context;
        ProductDao _productDao;

        public ProductController(ILogger<UserController> logger, MyDbContext context)
        {
            _logger = logger;
            _context = context;
            _productDao = new ProductDao(context);
        }

        [HttpGet("GetAll")]  // Attribute to indicate that this method responds to HTTP GET requests with the URL path "GetAll"
        public IEnumerable<Product> GetAll()
        {
            return _context.Product.ToList();  // Returns all products from the context as a List
        }

        [HttpPost("SearchByName")]  // Attribute to indicate that this method responds to HTTP POST requests with the URL path "SearchByName"
        public Product SearchByName(string name)
        {
            if (name != null)
            {
                return _productDao.SearchByName(name);  // Returns the product with the given name
            }
            return null;
        }

        [HttpPost("SearchByType")]  // Attribute to indicate that this method responds to HTTP POST requests with the URL path "SearchByType"
        public IEnumerable<Product> SearchByType(string type)
        {
            if (type != null)
            {
                return _productDao.SearchByType(type);  // Returns all products of the given type
            }
            return null;
        }

        [HttpPost("DeleteByName")]  // Attribute to indicate that this method responds to HTTP POST requests with the URL path "DeleteByName"
        public bool DeleteByName(string name)
        {
            if (name != null)
            {
                return _productDao.DeleteByName(name);  // Deletes the product with the given name and returns true if successful
            }
            return false;
        }

        [HttpPut("AddProduct")]  // Attribute to indicate that this method responds to HTTP PUT requests with the URL path "AddProduct"
        public string AddProduct(Product requestProduct)
        {
            return _productDao.AddProduct(requestProduct);  // Adds the given product to the database and returns a string message indicating success or failure
        }

        [HttpPut("UpdateProduct")]  // Attribute to indicate that this method responds to HTTP PUT requests with the URL path "UpdateProduct"
        public string UpdateProduct(Product requestProduct)
        {
            return _productDao.UpdateProduct(requestProduct);  // Updates the product with the given ID and returns a string message indicating success or failure
        }

        [HttpGet("GetHighestStock")]  // Attribute to indicate that this method responds to HTTP GET requests with the URL path "GetHighestStock"
        public IEnumerable<Product> GetHighestStock()
        {
            return _context.Product.Where(p => p.Stock > 0)  // Filters the products by stock greater than 0
                    .OrderByDescending(p => p.Stock)  // Sorts the products by stock in descending order
                    .ToList();  // Returns the products as a List
        }

        [HttpGet("GetLowestStock")]  // Attribute to indicate that this method responds to HTTP GET requests with the URL path "GetLowestStock"
        public IEnumerable<Product> GetLowestStock()
        {
            return _context.Product.Where(p => p.Stock > 0)  // Filters the products by stock greater than 0
                    .OrderBy(p => p.Stock)  // Sorts the products by stock in ascending order
                    .ToList();  // Returns the products as a List
        }


    }
}

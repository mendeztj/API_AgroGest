using API_AgroGest.Data;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using Models;

namespace API_AgroGest.Controllers
{
    public class ProductDao
    {
        private readonly MyDbContext _context;
        public ProductDao(MyDbContext context) {
            _context = context;
        }
       public Product SearchByName(string name)
        {
            var dbProduct = _context.Product.FirstOrDefault(u => u.Name.Equals(name));
            return dbProduct;
        }
        public IEnumerable<Product> SearchByType(string type) {
            return _context.Product.Where(u => u.Type.Equals(type));
        }

        public string AddProduct(Product requestProduct)
        {
            var name = requestProduct.Name;
            //Filter the product list by name
            var dbProduct = _context.Product.FirstOrDefault(u => u.Name.Equals(name));
            if (dbProduct == null)
            {
                //We create a new product
                _context.Product.Add(new Product
                {
                    Name = name,
                    Stock = requestProduct.Stock,
                    Image = requestProduct.Image,
                    Type = requestProduct.Type
                });

                _context.SaveChanges();

                return "added"; // el producto se agregó correctamente
            }
            else { return "not added"; }
        }

        public bool DeleteByName(string name) {
            var product = SearchByName(name);
            if (product != null)
            {
                _context.Product.Remove(product);
                return true;
            }
            return false;
        }

        public string UpdateProduct (Product requestProduct)
        {
            var name = requestProduct.Name;
            //Filter the product list by name
            var dbProduct = _context.Product.FirstOrDefault(u => u.Name.Equals(name));
            if (dbProduct != null)
            {
                //Product already exists in the database
                dbProduct.Name = name;
                dbProduct.Stock = requestProduct.Stock;
                dbProduct.Image = requestProduct.Image;
                dbProduct.Type = requestProduct.Type;
                _context.Product.Update(dbProduct);
                _context.SaveChanges();
                return "updated";
            }
            else { return "Can't found the Product"; }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public double Stock { get; set; }
        public string Image { get; set; }
        public Product() { }

        public Product(int id, string name, string type, double stock, string image)
        {
            Id = id;
            Name = name;
            Type = type;
            Stock = stock;
            Image = image;
        }

    }
}

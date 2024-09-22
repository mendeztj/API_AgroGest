using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    internal class Supply
    {
        int id;
        string name;
        string type;
        double price;

        public Supply(int id, string name, string type, double price)
        {
            this.Id = id;
            this.Name = name;
            this.Type = type;
            this.Price = price;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Type { get => type; set => type = value; }
        public double Price { get => price; set => price = value; }

        public override bool Equals(object obj)
        {
            return obj is Supply supply &&
                   Id == supply.Id &&
                   Name == supply.Name &&
                   Type == supply.Type &&
                   Price == supply.Price;
        }
    }
}

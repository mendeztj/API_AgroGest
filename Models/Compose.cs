using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    internal class Compose
    {
        public Compose() { }
        public int Id_product { get; set; }
        public int Id_invoice { get; set; }
        public double amount { get; set; }
        public double price { get; set; }

        public double total_product_price { get; set; }
        public string Name { get; set; }
    }
}

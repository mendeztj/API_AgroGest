using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    internal class Buy
    {
        public int Id_comercial { get; set; }

        public int Id_supply { get; set; }

        public int Id_user { get; set; }
        public DateTime date { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }

        public double total_price { get; set; }
        public Buy() { }

        public Buy(int id_comercial, int id_supply, int id_user, DateTime date, double quantity, double price, double total_price)
        {
            Id_comercial = id_comercial;
            Id_supply = id_supply;
            Id_user = id_user;
            this.date = date;
            Quantity = quantity;
            Price = price;
            this.total_price = total_price;
        }

        public override bool Equals(object obj)
        {
            return obj is Buy buy &&
                   Id_comercial == buy.Id_comercial &&
                   Id_supply == buy.Id_supply &&
                   Id_user == buy.Id_user &&
                   date == buy.date &&
                   Quantity == buy.Quantity &&
                   Price == buy.Price &&
                   total_price == buy.total_price;
        }
    }
}

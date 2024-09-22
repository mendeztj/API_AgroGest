using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Invoice
    {
        public Invoice() { }

        public Invoice(int id, DateTime date, int client_id, int client_cif, int total_product_price)
        {
            Id = id;
            Date = date;
            this.client_id = client_id;
            this.user_id = client_cif;
            this.total_invoice_price = total_product_price;
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public int client_id { get; set; }
        public int user_id { get; set; }
        public int total_invoice_price { get; set; }

        public override bool Equals(object obj)
        {
            return obj is Invoice invoice &&
                   Id == invoice.Id &&
                   Date == invoice.Date &&
                   client_id == invoice.client_id &&
                   user_id == invoice.user_id &&
                   total_invoice_price == invoice.total_invoice_price;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    internal class Sale
    {
        public int Id { get; set; }
        public int Id_user { get; set; }
        public int Id_invoice { get; set; }
        public int Id_client { get; set; }
        public Sale() { }

        public Sale(int id, int id_user, int id_invoice, int id_client)
        {
            Id = id;
            Id_user = id_user;
            Id_invoice = id_invoice;
            Id_client = id_client;
        }

        public override bool Equals(object obj)
        {
            return obj is Sale sale &&
                   Id == sale.Id &&
                   Id_user == sale.Id_user &&
                   Id_invoice == sale.Id_invoice &&
                   Id_client == sale.Id_client;
        }
    }
}

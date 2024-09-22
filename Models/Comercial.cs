using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    internal class Comercial
    {
        int id;
        string name;
        string address;
        string telefon;
        string email;

        public Comercial(int id, string name, string address, string telefon, string email)
        {
            this.Id = id;
            this.Name = name;
            this.Address = address;
            this.Telefon = telefon;
            this.Email = email;
        }

        public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Address { get => address; set => address = value; }
        public string Telefon { get => telefon; set => telefon = value; }
        public string Email { get => email; set => email = value; }

        public override bool Equals(object obj)
        {
            return obj is Comercial comercial &&
                   Id == comercial.Id &&
                   Name == comercial.Name &&
                   Address == comercial.Address &&
                   Telefon == comercial.Telefon &&
                   Email == comercial.Email;
        }
    }
}

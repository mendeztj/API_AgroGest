using System;

namespace Models
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Cif { get; set; }
        public string Address { get; set; }
        public string Telefon { get; set; }
        public string Email { get; set; }

        public Client() { }

        public Client(int id, string name, string cif, string address, string telefon, string email)
        {
            Id = id;
            Name = name;
            Cif = cif;
            Address = address;
            Telefon = telefon;
            Email = email;
        }

        public override bool Equals(object obj)
        {
            return obj is Client client &&
                   Id == client.Id &&
                   Name == client.Name &&
                   Cif == client.Cif &&
                   Address == client.Address &&
                   Telefon == client.Telefon &&
                   Email == client.Email;
        }
    }
}

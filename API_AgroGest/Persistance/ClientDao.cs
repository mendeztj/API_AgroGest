using API_AgroGest.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Models;

namespace API_AgroGest.Controllers
{
    public class ClientDao
    {
        private readonly MyDbContext _context;
        public ClientDao(MyDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Client> SearchByName(string name)
        {
            var dbClient = _context.Client.Where((u => u.Name.Equals(name)));
            return dbClient;
        }

        public IEnumerable<Client> SearchByCif(string cif)
        {
            return _context.Client.Where(u => u.Cif.Equals(cif));
        }

        public string UpdateClient(Client requestClient)
        {
            // Filter the client list by cif
            var dbClient = _context.Client.FirstOrDefault(u => u.Cif.Equals(requestClient.Cif));
            if (dbClient != null) //Client exists in the database
            {
                dbClient.Name = requestClient.Name;
                dbClient.Cif = requestClient.Cif;
                dbClient.Address = requestClient.Address;
                dbClient.Telefon = requestClient.Telefon;
                dbClient.Email = requestClient.Email;
                _context.Client.Update(dbClient);
                var rowsAffected = _context.SaveChanges();
                return "Updated, Rows Affected: " + rowsAffected;
            }
            else { return "Client doesn't exist"; }
        }

        public string AddClient(Client requestedClient)
        {
            var cif = requestedClient.Cif;
            // Filter the client list by cif
            var dbClient = _context.Client.FirstOrDefault(u => u.Cif.Equals(cif));
            if (dbClient == null)
            {
                // We create a new Client
                _context.Client.Add(new Client
                {
                    Name = requestedClient.Name,
                    Cif = requestedClient.Cif,
                    Address = requestedClient.Address,
                    Telefon = requestedClient.Telefon,
                    Email = requestedClient.Email
                });

                _context.SaveChanges();

                return "Client added"; // el cliente se agregó correctamente
            }
            else { return "Client not added"; }
        }

        public string DeleteClient(string cif)
        {
            var dbClient = _context.Client.FirstOrDefault(u => u.Cif.Equals(cif));
            if (dbClient != null)
            {
                _context.Client.Remove(dbClient);
                _context.SaveChanges();
                return "Client deleted";
            }
            else
            {
                return "Client not found";
            }
        }


    }
}

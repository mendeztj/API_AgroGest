using API_AgroGest.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Logging;
using Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using static System.Net.WebRequestMethods;
using System.Reflection.Metadata;
using System.Security.Policy;
using System.Xml.Linq;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace API_AgroGest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly MyDbContext _context;
        ClientDao _clientDao;

        public ClientController(ILogger<UserController> logger, MyDbContext context)
        {
            _logger = logger;
            _context = context;
            _clientDao = new ClientDao(context);
        }
        /// This method handles an HTTP GET request to the "GetAllClients" route. When called, it returns a list of all clients stored in the _context database context.
        [HttpGet("GetAllClients")]
        public IEnumerable<Client> GetAll()
        {
            return _context.Client.ToList();
        }
        ///This method handles an HTTP POST request to the "SearchByName" route.The method takes a name parameter in the request and searches the database for all clients whose name contains name.If at least one client is found, it returns a list of all found clients. If no clients are found, it returns an empty list.
        [HttpPost("SearchByName")]
        public IEnumerable<Client> SearchByName( string name)
        {
            if (name != null) {
                return _clientDao.SearchByName(name);
            }
            return null;
        }
        /// <summary>
        /// This method handles an HTTP POST request to the "SearchByCif" route. The method takes a cif parameter in the request and searches the database 
        /// for all clients whose CIF (tax identification number) contains cif. If at least one client is found, it returns a list of all found clients. 
        /// If no clients are found, it returns an empty list.
        /// <param name="cif"></param>
        /// <returns></returns>
        [HttpPost("SearchByCif")]
        public IEnumerable<Client> SearchByCif(string cif)
        {
            if (cif != null)
            {
                return _clientDao.SearchByCif(cif);
            }
            return null;
        }

        /// <summary>
        /// This method handles an HTTP PUT request to the "AddClient" route.
        /// The method takes a Client object in the request, adds it to the database, and returns a string indicating whether the operation was performed successfully.
        /// <param name="requestedClient"></param>
        /// <returns></returns>
        [HttpPut("AddClient")]
        public string AddClient([FromBody] Client requestedClient)
        {
            return _clientDao.AddClient(requestedClient);
        }


        [HttpDelete("DeleteClient")]
        public string DeleteClient(string cif)
        {
            return _clientDao.DeleteClient(cif);
        }

    }
}

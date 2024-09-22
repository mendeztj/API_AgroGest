using API_AgroGest.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;


namespace API_AgroGest.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private readonly MyDbContext _context;
        UserDao _userDao;
        private readonly IConfiguration _configuration;

        public UserController(ILogger<UserController> logger, MyDbContext context, IConfiguration configuration)
        {
            _logger = logger;
            _context = context;
            _userDao = new UserDao(context);
            _configuration = configuration;
        }
        private string GenerateJwtToken(string email)
        {
            var user = _userDao.getUserByEmail(email);
            if (user == null)
            {
                return null;
            }

            var secretKey = _configuration["JwtSettings:SecretKey"];
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[]
            {
        new Claim(JwtRegisteredClaimNames.Sub, email),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        new Claim(ClaimTypes.Role, user.Role), // Agrega la información del rol del usuario
    };

            var token = new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddDays(7),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }



        [HttpGet("GetAll")]
        public IEnumerable<User> GetAll()
        {
            return _context.Users.ToList();
        }


        [HttpPost("Authenticate")]
        public IActionResult Authenticate([FromBody] User requestUser)
        {
            var authenticated = _userDao.Login(requestUser);

            if (!authenticated)
            {
                return Unauthorized();
            }

            var token = GenerateJwtToken(requestUser.Email);
            return Ok(new { Token = token });
        }


        [HttpPut("AddUser")]
        public string AddUser([FromBody] User requestUser)
        {
            return _userDao.AddUser(requestUser);
        }

        [HttpPut("UpdateUser")]
        public string UpdateUser([FromBody] User requestUser)
        {
            return _userDao.UpdateUser(requestUser);
        }

        [HttpPost("getUserByEmail")]
        public User getUserByEmail(String email)
        {
            return _userDao.getUserByEmail(email);
        }

        [HttpPost("DeleteUserByDniAndEmail")]
        public bool DeleteUserByDniAndEmail([FromBody] User requestUser)
        {
            return _userDao.DeleteUserByDniAndEmail(requestUser);
        }

        [HttpGet("GetUsersByRole")]
        public IEnumerable<User> GetUsersByRole(String role)
        {
            if (role.Equals("Admin", StringComparison.OrdinalIgnoreCase) || role.Equals("Employee", StringComparison.OrdinalIgnoreCase))
            {
                return _context.Users.Where(u => u.Role.Equals(role));
            }
            else { return null; }
        }


    }
}

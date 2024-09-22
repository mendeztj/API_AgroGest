using API_AgroGest.Data;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Models;
using System;

namespace API_AgroGest.Controllers
{
    public class UserDao
    {
        private readonly MyDbContext _context;
        public UserDao(MyDbContext context)
        {
            _context = context;
        }
        public bool Login(User requestUser)
        {

            var email = requestUser.Email;
            var password = requestUser.Password;

            var dbUser = _context.Users.FirstOrDefault(u => u.Email.Equals(email));

            if (dbUser != null && string.Equals(dbUser.Password, password))
            {
                return true;
            }
            return false;
        }
        public string AddUser(User requestUser)
        {
            try
            {
                // Comprueba si el correo electrónico o el DNI ya existen en la base de datos
                var dbUser = _context.Users.FirstOrDefault(u => u.Email.Equals(requestUser.Email) || u.Dni.Equals(requestUser.Dni));
            if (dbUser != null)
            {
                return "Email or Dni repeated";
            }

            // Comprueba si el rol está correctamente definido
            if (requestUser.Role != "Admin" && requestUser.Role != "Employee")
            {
                return "Incorrect Role input";
            }

            // Crea un nuevo usuario y lo guarda en la base de datos
            _context.Users.Add(new User
            {
                Name = requestUser.Name,
                Email = requestUser.Email,
                Password = requestUser.Password,
                Address = requestUser.Address,
                Cif = requestUser.Cif,
                Dni = requestUser.Dni,
                Role = requestUser.Role
            });
            _context.SaveChanges();

            return "User added"; // El usuario se agregó correctamente
            }
            catch (Exception ex)
            {
                return $"Error adding user: {ex.Message}";
            }
        }


        public User getUserByEmail(string emailRequestedUser)
        {
            var dbUser = _context.Users.FirstOrDefault(u => u.Email.Equals(emailRequestedUser));
            if (dbUser != null) { return dbUser; }
            else { return null; }
        }
        public bool DeleteUserByDniAndEmail(User requestUser)
        {
            var dbUser = _context.Users.FirstOrDefault(u => u.Email.Equals(requestUser.Email) && u.Dni.Equals(requestUser.Dni));
            if (dbUser != null)
            {
                _context.Users.Remove(dbUser);
                _context.SaveChanges(); // Asegúrate de guardar los cambios en la base de datos
                return true;
            }
            return false;
        }

        public string UpdateUser(User requestUser) { 
            var dbUser = getUserByEmail(requestUser.Email);
            if (dbUser != null)
            {
                dbUser.Id = dbUser.Id;
                dbUser.Name = requestUser.Name;
                dbUser.Email = requestUser.Email;
                dbUser.Password = requestUser.Password;
                dbUser.Address = requestUser.Address;
                dbUser.Cif = requestUser.Cif;
                dbUser.Dni = requestUser.Dni;
                dbUser.Role = requestUser.Role;
                if (dbUser.Role == "Admin" || dbUser.Role == "Employee")
                {// Comprobamos que el rol sea admin o employee
                    if (_context.Users.Count(u => u.Dni.Equals(dbUser.Dni)) <= 1)// Comprobamos que el Dni no se repita en la databse
                    {
                        _context.Users.Update(dbUser);
                        _context.SaveChanges();
                        return "updated"; // el usuario ya existe en la base de datos
                    }
                    else { return "DNI Repeated"; }
                }
                else { return "Incorrect Role input"; }
            }
            else { return "User not found in database"; }
        }
    }
}

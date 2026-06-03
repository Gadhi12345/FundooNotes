using BCrypt.Net;
using DataBaseLayer.Context;
using DataBaseLayer.Interface;
using Microsoft.EntityFrameworkCore;
using ModelLayer.DTO.User;
using ModelLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseLayer.Repository
{
    public class UserDAL : IUserDAL
    {
        private readonly UserDbContext _context;
        public UserDAL(UserDbContext context)
        {
            _context = context;
        }

       
        public User LoginUser(string Email)
        {
            return _context.Users
             .FirstOrDefault(x => x.Email == Email);
        }

        public User RegiserUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }

      
    }
}

using DataBaseLayer.Context;
using DataBaseLayer.Interface;
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

        public User RegiserUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user;
        }
    }
}

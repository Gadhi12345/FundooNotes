using BussinessLogicLayer.Interface;
using DataBaseLayer.Interface;
using ModelLayer.DTO.User;
using ModelLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BCrypt.Net;

namespace BussinessLogicLayer.Services
{
    public class UserBLL : IUserBLL
    {

        private readonly IUserDAL _userDAL;
        public UserBLL(IUserDAL userDAL)
        {
            _userDAL= userDAL;
        }

        public UserResponse RegisterUser(RegisterUserRequest userRequest)
        {
            User user = new User()
            {
                FirstName = userRequest.FirstName,
                LastName= userRequest.LastName,
                Email= userRequest.Email,
                Password=BCrypt.Net.BCrypt.HashPassword(userRequest.Password),
                ChangedAt= DateTime.Now,
                CreatedAt=DateTime.Now
            };
            user = _userDAL.RegiserUser(user);


            UserResponse userResponse = new UserResponse()
            {
                UserId = user.UserId,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email
            };

            return userResponse;

        }
    }
}

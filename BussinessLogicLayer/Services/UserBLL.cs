using BCrypt.Net;
using BussinessLogicLayer.Interface;
using DataBaseLayer.Interface;
using DataBaseLayer.Repository;
using ModelLayer.DTO.User;
using ModelLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace BussinessLogicLayer.Services
{
    public class UserBLL : IUserBLL
    {

        private readonly IUserDAL _userDAL;
        private readonly IUserEmail _userEmail;
        public UserBLL(IUserDAL userDAL, IUserEmail userEmail)
        {
            _userDAL = userDAL;
            _userEmail = userEmail;
        }

        public async Task<bool> LoginUser(LoginRequest loginRequest)
        {
            User user = _userDAL.LoginUser(loginRequest.Email);

            if (user == null)
            {
                return false;
            }

            bool result = BCrypt.Net.BCrypt.Verify(

                loginRequest.Password,
                user.Password);

            return result;

        }

      

        public async Task<UserResponse> RegisterUser(RegisterUserRequest userRequest)
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
            await _userEmail.SendEmail(user.Email, "Welcome to Fundoo Notes", "Your account created succesdsfully");


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

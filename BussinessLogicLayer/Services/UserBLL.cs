using BCrypt.Net;
using BussinessLogicLayer.Interface;
using DataBaseLayer.Interface;
using DataBaseLayer.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ModelLayer.DTO.User;
using ModelLayer.Entity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
namespace BussinessLogicLayer.Services
{
    public class UserBLL : IUserBLL
    {

        private readonly IUserDAL _userDAL;
        private readonly IUserEmail _userEmail;
        private readonly IConfiguration _configuration;
        public UserBLL(IUserDAL userDAL, IUserEmail userEmail, IConfiguration configuration)
        {
            _userDAL = userDAL;
            _userEmail = userEmail;
            _configuration = configuration;
        }

        private string GenerateToken(User user)
        {
            string key = _configuration["Jwt:Key"];

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));

            var credentials = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);

            var claims = new[]{
            new Claim("UserId", user.UserId.ToString()),
            new Claim("Email", user.Email)
            };

            var token = new JwtSecurityToken(  issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddHours(1),
                signingCredentials: credentials
                );
            var tokenHandler = new JwtSecurityTokenHandler();

            string tokenString = tokenHandler.WriteToken(token);

            return tokenString;
        }
        
        public async Task<string> LoginUser(LoginRequest loginRequest)
        {
            User user = _userDAL.LoginUser(loginRequest.Email);

            if (user == null)
            {
                return null;
            }

            bool result = BCrypt.Net.BCrypt.Verify(

                loginRequest.Password,
                user.Password);
            if (!result)
            {
                return null;
            }

            string token = GenerateToken(user);

            return token;

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

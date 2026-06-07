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
            string body = $@"
<!DOCTYPE html>
<html>
<head>
</head>
<body style='font-family: Arial, sans-serif; background-color: #f4f6f9; padding: 20px;'>

    <div style='max-width: 700px; margin: auto; background-color: white;
                border-radius: 10px; overflow: hidden;
                box-shadow: 0px 2px 10px rgba(0,0,0,0.1);'>

        <div style='background-color: #1976D2;
                    color: white;
                    padding: 30px;
                    text-align: center;'>

            <h1 style='margin:0;'>Fundoo Notes</h1>
            <p style='margin-top:10px;'>Connecting Worlds, Creating History</p>
        </div>

        <div style='padding: 30px;'>

            <h2>Hello {user.FirstName}! 👋</h2>

            <p>
                Your Fundoo Notes account has been created successfully.
            </p>

            <p>
                We're excited to have you onboard.
                Every great journey begins with a single note. ✨
            </p>

            <div style='background-color:#E3F2FD;
                        padding:15px;
                        border-radius:8px;
                        margin-top:20px;'>

                <h3>Account Details</h3>

                <p>
                    <b>Name:</b> {user.FirstName}
                </p>

                <p>
                    <b>Email:</b> {user.Email}
                </p>

            </div>

            <p style='margin-top:25px;'>
                Thank you for joining Fundoo Notes.
                We look forward to helping you organize your ideas,
                memories, and goals.
            </p>

            <p>
                Best Wishes,<br><br>
                <b>Adarsh Gadhiraju</b><br>
                .NET Trainee
            </p>

        </div>

        <div style='background-color:#f5f5f5;
                    text-align:center;
                    padding:15px;'>

            © Fundoo Notes | Welcome Aboard 🚀

        </div>

    </div>

</body>
</html>";

            await _userEmail.SendEmail(user.Email, "Welcome to Fundoo Notes",body );


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

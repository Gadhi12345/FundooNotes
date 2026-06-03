using ModelLayer.DTO.User;
using ModelLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogicLayer.Interface
{
    public interface IUserBLL
    {
        Task<UserResponse> RegisterUser(RegisterUserRequest userRequest);
        Task<bool> LoginUser(LoginRequest loginRequest);
    }
}

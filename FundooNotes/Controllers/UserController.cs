using BussinessLogicLayer.Interface;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using ModelLayer.DTO.User;
using RouteAttribute = Microsoft.AspNetCore.Mvc.RouteAttribute;

namespace FundooNotes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController:ControllerBase
    {
        private readonly IUserBLL _userBLL;
        public UserController(IUserBLL userBLL)
        {
            _userBLL = userBLL;
        }
        [HttpPost]
        public UserResponse RegisterUser(RegisterUserRequest userRequest)
        {
            return _userBLL.RegisterUser(userRequest);
        }
    }
}

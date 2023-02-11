using AuthSevice.Database.Entities;
using AuthSevice.Models;
using AuthSevice.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AuthSevice.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthenticationService _authService;

        public AuthController(IAuthenticationService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IEnumerable<UserModel> GetUsers()
        {
            return _authService.GetUsers();
        }

        [HttpPost]
        public IActionResult CreateUser(SignUpModel model)
        {
            User user = new User
            {
                Email = model.Email,
                Name = model.Name,
                PhoneNumber = model.PhoneNumber,
                Password = model.Password
            };
            var result = _authService.CreateUser(user, model.Role);
            if (result)
            {
                return CreatedAtAction("CreteUser", user);
            }
            else
                return BadRequest();
        }


        [HttpPost]
        public IActionResult ValidateUser(LoginModel model)
        {
            UserModel user = _authService.ValidateUser(model);
            if (user != null)
                return Ok(user);
            else
                return NoContent();
        }



    }
}

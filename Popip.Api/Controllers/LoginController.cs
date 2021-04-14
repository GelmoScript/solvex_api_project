using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Popip.Infrastructure.Dtos;
using Popip.Service.Users;

namespace Popip.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IUserService _userService;
        public LoginController(IUserService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login([FromBody] UserDto login)
        {
            UserDto user = _userService.AuthenticateUser(login);
            if (user is null)
                return Unauthorized();

            var tokenString = _userService.GenerateJWTToken(user);
            return Ok(new
            {
                token = tokenString,
                userDetails = user,
            });
        }



    }
}

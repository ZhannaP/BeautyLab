using BLL.Security;
using BLL.Services.Interfaces;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BeautyLabV2.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IJwtTokenService _jwtService;

        public AuthController(IUserService userService, IJwtTokenService jwtService)
        {
            _userService = userService;
            _jwtService = jwtService;
        }

        [HttpPost("login")]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var user = await _userService.GetByEmailAsync(request.Email);

            if (user == null)
                return Unauthorized("Invalid credentials");

            // ❗ TEMP (replace with hash check later)
            if (user.Password != request.Password)
                return Unauthorized("Invalid credentials");

            var token = _jwtService.GenerateToken(
                user.UserId,
                user.Email,
                user.RoleName
            );

            if (token == null)
                throw new Exception("SecretKey is NULL at GenerateToken()");

            return Ok(new
            {
                token
            });


        }
    }

    public class LoginRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }

}

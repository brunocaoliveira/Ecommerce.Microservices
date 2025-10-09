using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Auth.API.Models;
using Auth.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace Auth.API.Controllers
{


    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly TokenService _tokenService;

        private static readonly List<Models.User> Users = new()
            {
                new User { Id = 1, Username = "bruno", Password = "123" },
                new User { Id = 2, Username = "admin", Password = "admin" }
            };
        public AuthController(TokenService tokenService)
        {
            _tokenService = tokenService;
        }
        [HttpPost("login")]
        public ActionResult Login([FromBody] DTOs.LoginDto loginDto)
        {
            var user = Users.SingleOrDefault(u => u.Username == loginDto.Username && u.Password == loginDto.Password);
            if (user == null)
            {
                return Unauthorized("Usuário ou senha inválidos.");
            }
            var token = _tokenService.GenerateToken(user);
            return Ok(new { Token = token });
        }
    }
}

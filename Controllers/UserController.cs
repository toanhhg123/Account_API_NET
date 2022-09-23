using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AccountApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace AccountApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{


    private readonly ILogger<UserController> _logger;
    private readonly IConfiguration _configuration;

    public UserController(ILogger<UserController> logger, IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
    }

    [Route("login")]
    [HttpPost]
    public IActionResult Login(User user)
    {

        if (ModelState.IsValid)
        {
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];
            var key = Encoding.UTF8.GetBytes
            (_configuration["Jwt:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new List<Claim>
                {
                new Claim("Id", "123"),
                new Claim("username", "123"),
                new Claim("role_cus", "456"),
                new Claim("role_cus1", "456"),


                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Email, user.UserName),
                new Claim(ClaimTypes.Role, "admin"),

                new Claim(JwtRegisteredClaimNames.Jti,
                Guid.NewGuid().ToString())
             }),
                Expires = DateTime.Now.AddSeconds(20),
                Issuer = issuer,
                Audience = audience,
                SigningCredentials = new SigningCredentials
                (new SymmetricSecurityKey(key),
                SecurityAlgorithms.HmacSha512Signature)
            };
            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var jwtToken = tokenHandler.WriteToken(token);
            var stringToken = tokenHandler.WriteToken(token);
            return Ok(stringToken);
        }
        return BadRequest();
    }



}

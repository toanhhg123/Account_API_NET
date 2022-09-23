using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AccountApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;


namespace AccountApi.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthController : ControllerBase
{

    private readonly ILogger<AuthController> _logger;

    private readonly IHttpContextAccessor _contextAccessor;
    private readonly MyDbContext _dbContext;

    public AuthController(ILogger<AuthController> logger, IHttpContextAccessor contextAccessor, MyDbContext dbContext)
    {
        _logger = logger;
        _contextAccessor = contextAccessor;
        _dbContext = dbContext;
    }
    private async Task<bool> AddUser(UserRegister userRegister)
    {
        try
        {
            
            var user =  _dbContext.Users.FirstOrDefault(x => x.Email == userRegister.Email);
            if(user != null)
                throw new Exception("email is exits");

            var newUser = new User(){
                UserName = userRegister.UserName,
                Email = userRegister.Password,
                Salt = Guid.NewGuid(),
            } ;

            return true;
        }
        catch (System.Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register(UserRegister userRegister)
    {
        try
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("is valid user from client");
            };



            return Ok(userRegister);
        }
        catch (System.Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
    [HttpPost]
    [Route("login/{id}")]
    public async Task<IActionResult> Login(string id)
    {
        return Ok(id);
    }

}

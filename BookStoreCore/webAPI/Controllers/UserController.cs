using Microsoft.AspNetCore.Mvc;
using webAPI.Application.UserOperations.Commands.CreateToken;
using webAPI.Application.UserOperations.Commands.CreateUser;
using webAPI.Application.UserOperations.Commands.RefreshToken;
using webAPI.Application.UserOperations.Queries;
using webAPI.DBOperations;
using webAPI.TokenOperations.Models;

namespace webAPI.Controllers
{
    [ApiController]
    [Route("[Controller]s")]
    public class UserController : ControllerBase
    {
        private readonly IBookStoreDbContext _context;
        private readonly IConfiguration _conf;

        public UserController(IBookStoreDbContext context, IConfiguration conf)
        {
            _context = context;
            _conf = conf;
        }

        [HttpPost]
        public IActionResult Create([FromBody] CreateUserModel newUser)
        {
            CreateUserCommand command = new(_context);
            command.MyModel = newUser;
            command.Handle();
            return Ok();
        }

        [HttpPost("connect/token")]
        public ActionResult<Token> CreateToken([FromBody] CreateTokenModel login)
        {
            CreateTokenCommand command = new(_context, _conf);
            command.MyModel = login;
            var token = command.Handle();
            return token;
        }

        [HttpGet("refresh/token")]
        public ActionResult<Token> RefreshToken([FromQuery] string refreshToken)
        {
            RefreshTokenCommand command = new(_context, _conf);
            command.RefreshToken = refreshToken;
            var result = command.Handle();
            return result;
        }

        [HttpGet]
        public IActionResult Users()
        {
            GetUsersQuery query = new(_context);
            var result = query.Handle();
            return Ok(result);
        }
    }
}

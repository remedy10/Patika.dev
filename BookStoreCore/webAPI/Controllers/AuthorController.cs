using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using webAPI.Application.AuthorOperations.Commands.CreateAuthor;
using webAPI.Application.AuthorOperations.Commands.DeleteAuthor;
using webAPI.Application.AuthorOperations.Commands.UpdateAuthor;
using webAPI.Application.AuthorOperations.Queries.GetAuthors;

using webAPI.DBOperations;

namespace webAPI.Controllers
{
    [ApiController]
    [Route("[Controller]s")]
    public class AuthorController : ControllerBase
    {
        private readonly BookStoreDbContext _context;

        public AuthorController(BookStoreDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Authors()
        {
            GetAuthorsQuery query = new(_context);
            var result = query.Handle();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public IActionResult Author(int id)
        {
            GetAuthorByIdQuery query = new(_context);
            var result = query.Handle(id);
            return Ok(result);
        }

        [HttpPost]
        public IActionResult CreateAuthor([FromBody] CreateAuthorModel model)
        {
            CreateAuthorCommand createAuthorCommand = new(_context);
            CreateAuthorCommandValidator validationRules = new();
            createAuthorCommand.MyCreateModel = model;
            validationRules.ValidateAndThrow(createAuthorCommand);
            createAuthorCommand.Handle();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAuthor(int id, [FromBody] AuthorUpdateModel model)
        {
            UpdateAuthorCommand command = new(_context);
            command.MyModel = model;
            UpdateAuthorCommandValidator validationRules = new();
            validationRules.ValidateAndThrow(command);
            command.Handle(id);
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAuthor(int id)
        {
            DeleteAuthorCommand command = new(_context);
            command.Handle(id);
            return Ok();
        }
    }
}

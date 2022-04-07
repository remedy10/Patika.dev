using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using webAPI.Application.GenreOperations.Commands.CreateGenre;
using webAPI.Application.GenreOperations.Commands.DeleteGenre;
using webAPI.Application.GenreOperations.Commands.UpdateGenre;
using webAPI.Application.GenreOperations.Queries.GetGenres;
using webAPI.DBOperations;

namespace webAPI.Controllers
{
    [ApiController]
    [Route("[Controller]s")]
    public class GenreController : ControllerBase
    {
        private readonly BookStoreDbContext _bookStoreDbContext;

        public GenreController(BookStoreDbContext bookStoreDbContext)
        {
            _bookStoreDbContext = bookStoreDbContext;
        }

        [HttpGet]
        public IActionResult Genres()
        {
            GetGenresQuery getGenres = new(_bookStoreDbContext);
            var genresResult = getGenres.Handle();
            return Ok(genresResult);
        }

        [HttpGet("{id}")]
        public IActionResult Genre(int id) //! GET-GenreByID
        {
            GetGenresByIdQuery getGenres = new(_bookStoreDbContext);
            var genresResult = getGenres.Handle(id);
            return Ok(genresResult);
        }

        [HttpPost]
        public IActionResult AddGenre([FromBody] CreateGenreModel model)
        {
            CreateGenreCommand genreCommand = new(_bookStoreDbContext);
            CreateGenreValidator genreValidator = new();
            genreCommand.MyCreateModel = model;
            genreValidator.ValidateAndThrow(genreCommand);
            genreCommand.Handle();
            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult UpdateGenre(int id, [FromBody] UpdateGenreModel model)
        {
            UpdateGenreCommand genreCommand = new(_bookStoreDbContext);
            genreCommand.updatedGenreId = id;
            UpdateGenreCommandValidator genreValidator = new();
            genreCommand.UpdateModel = model;
            genreValidator.ValidateAndThrow(genreCommand);
            genreCommand.Handle();
            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteGenre(int id)
        {
            DeleteGenreCommand genreCommand = new(_bookStoreDbContext);
            genreCommand.Handle(id);
            return Ok();
        }
    }
}

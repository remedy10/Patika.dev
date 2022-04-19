using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using webAPI.DBOperations;
using webAPI.Applicaton.BookOperations.Queries.GetBooks;
using static webAPI.Applicaton.BookOperations.Commands.CreateBook.CreateBookCommand;
using webAPI.Applicaton.BookOperations.Commands.CreateBook;
using webAPI.Applicaton.BookOperations.Commands.UpdateBook;
using webAPI.Applicaton.BookOperations.Commands.DeleteBook;
using Microsoft.AspNetCore.Authorization;

namespace webAPI.Controllers
{   
    [Authorize]
    [ApiController]
    [Route("[Controller]s")]
    public class BookController : ControllerBase
    {
        private readonly IBookStoreDbContext _context;
        
        public BookController(IBookStoreDbContext context) //dependency injection ıoc containerden context'i istiyoruz.
        {
            _context = context;
        }

        #region GET
        [HttpGet] //Get All books
        public IActionResult Books()
        {
            GetBooksQuery query = new(_context);
            var result = query.GetQuery();
            return Ok(result);
        }

        [HttpGet("{id}")] //Route almak
        //! id puarametresine göre filtreleme yapıyoruz bnu query ile de yapabiliriz ama o pek iyi değil-
        //! aynı methoda [FromQuery] ile bir param veriyoruz
        public IActionResult getById(int id)
        {
            GetBookByIdQuery getBookById = new(_context);
            var book = getBookById.Handle(id);
            return Ok(book);
        }
        #endregion

        #region  POST
        [HttpPost]
        public IActionResult addBook([FromBody] CreateModel newBook)
        {
            CreateBookCommand createBook = new(_context);
            createBook.MyCreateModel = newBook;
            CreateBookValidator addValidator = new();
            addValidator.ValidateAndThrow(createBook);
            createBook.Handle();
            //! ValidateAndThrow hem doğrular ve hata oluşması durumdan hatayı fırlatır. sadece validate kullanmak
            //! iyi olmaz.
            //? Artık bütün exceptionlarımız tek yerden geliyor.try-catch yazmaya gerek yok  
            return Ok();
        }
        #endregion

        #region PUT
        [HttpPut("{id}")]
        public IActionResult updateBook(int id, [FromBody] UpdateBookQuery.UpdateModel upBook)
        {
            UpdateBookValidator updateValidator = new();
            UpdateBookQuery updateBook = new(_context);
            updateBook.MyModel = upBook;
            updateValidator.ValidateAndThrow(updateBook);
            updateBook.Handle(id);
            return Ok();
        }

        #endregion

        #region DELETE
        [HttpDelete("{id}")]
        public IActionResult deleteBook(int id)
        {
            DeleteBookCommand delete = new(_context);
            //DeleteBookValidator deleteValidator = new();
            delete.Handle(id);
            //deleteValidator.ValidateAndThrow(delete);
            return Ok();
        }
        #endregion
    }
}

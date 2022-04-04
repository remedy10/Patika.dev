using Microsoft.AspNetCore.Mvc;
using webAPI.DBOperations;
using webAPI.Models.GetBooks;
using webAPI.ViewModels.GetBooks;
using static webAPI.ViewModels.GetBooks.CreateBook;

namespace webAPI.Controllers
{
    [ApiController]
    [Route("[Controller]s")]
    public class BookController : ControllerBase
    {
        private readonly BookStoreDbContext _context;

        public BookController(BookStoreDbContext context) //dependency injection ıoc containerden context'i istiyoruz.
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
            getBookById getBookById = new(_context);
            try
            {
                var book = getBookById.Handle(id);
                return Ok(book);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

        #region  POST
        [HttpPost]
        public IActionResult addBook([FromBody] CreateModel newBook)
        {
            CreateBook createBook = new(_context);
            try
            {
                createBook.MyCreateModel = newBook;
                createBook.Handle();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
            return Ok();
        }
        #endregion

        #region PUT
        [HttpPut("{id}")]
        public IActionResult updateBook(int id, [FromBody] Book upBook)
        {
            var book = _context.Books.SingleOrDefault(x => x.bookId == id);
            if (book == null)
                return BadRequest();
            book.bookId = upBook.bookId != default ? upBook.bookId : book.bookId;
            //ternary if şeklinde diyoruz ki , gelen değer default değilse(yani boş değilse) gelen değeri book id olarak ata
            // eğer boşşa kendi değerini kullan diyoruz
            book.bookPage = upBook.bookPage != default ? upBook.bookPage : book.bookPage;
            book.bookRelase = upBook.bookRelase != default ? upBook.bookRelase : book.bookRelase;
            book.bookTitle = upBook.bookTitle != default ? upBook.bookTitle : book.bookTitle;
            _context.SaveChanges();
            return Ok();
        }

        #endregion

        #region DELETE
        [HttpDelete("{id}")]
        public IActionResult deleteBook(int id)
        {
            var book = _context.Books.SingleOrDefault(x => x.bookId == id);
            if (book == null)
                return BadRequest();
            _context.Books.Remove(book);
            _context.SaveChanges();
            return Ok();
        }
        #endregion
    }
}

using System;
using System.Linq;
using FluentAssertions;
using webAPI.Application.AuthorOperations.Commands.CreateAuthor;
using webAPI.DBOperations;
using webAPI.Entities;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.AuthorOperations.Commands.CreateCommandTest
{
    public class CreateAuthorCommandTest : IClassFixture<CommonTestFixture>
    {
        private readonly BookStoreDbContext _context;

        public CreateAuthorCommandTest(CommonTestFixture commonTestFixture)
        {
            _context = commonTestFixture.BookStoreDbContext;
            //!context'e CommonTestFixture'den gelen dbcontext'i veriyoruz.
        }

        [Fact]
        public void WhenAuthorAlreadyExist_InvalidException_ShouldReturn()
        {
            // AAA kuralina göre Arrenge,Act,Assert işlemlerini yapacağız.
            //Arrenge
            var author = new Author()
            {
                NameAndSurname = "Test Testoğlu",
                DateOfBirth = new System.DateTime(1998, 12, 28)
            }; //! Burada çok fazla değer dönmeye gerek yok zaten authorTitle'ın daha önce varolup,
            //!   olmadığını kontrol edeceğimiz için sadece onu girsek bile yeter.
            _context.Authors.Add(author);
            _context.SaveChanges();

            CreateAuthorCommand command = new(_context);
            command.MyCreateModel = new CreateAuthorModel()
            {
                NameAndSurname = "Test Testoğlu",
                BirthOfDate = new System.DateTime(1998, 12, 28) //! test etmek için yeniden yaratıyoruz.
            };
            FluentActions
                .Invoking(() => command.Handle())
                .Should()
                .Throw<InvalidOperationException>()
                .And.Message.Should()
                .Be("Yazar zaten mevcut");
        }

        [Fact]
        public void WhenAuthorInputAreGiven_Validator_ShouldntReturnExceptino() //Happy Path
        {
            //arrange
            CreateAuthorCommand command = new(_context);
            var author = new CreateAuthorModel()
            {
                NameAndSurname = "Test Testoğlu2",
                BirthOfDate = System.DateTime.Now.AddYears(-1).Date
            };
            command.MyCreateModel = author;
            //act
            FluentActions.Invoking(() => command.Handle()).Invoke(); //invoke demezsen Handle()'i çağırmaz
            //assert(verimiz eklenmişmi bakıyorum.)
            var query = _context.Authors.SingleOrDefault(
                x => x.NameAndSurname == command.MyCreateModel.NameAndSurname
            )!;
            query.Should().NotBeNull();
            query.NameAndSurname.Equals("Test Testoğlu"); //veya modelden de alabilirsin
            query.DateOfBirth.Equals(System.DateTime.Now.AddYears(-1).Date);
        }
    }
}

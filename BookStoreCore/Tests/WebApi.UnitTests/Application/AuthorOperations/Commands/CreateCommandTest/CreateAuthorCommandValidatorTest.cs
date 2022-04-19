using FluentAssertions;
using webAPI.Application.AuthorOperations.Commands.CreateAuthor;
using webAPI.Applicaton.BookOperations.Commands.CreateBook;
using WebApi.UnitTests.TestSetup;
using Xunit;

namespace WebApi.UnitTests.Application.AuthorOperations.Commands.CreateCommandTest
{
    public class CreateAuthorCommandValidatorTest : IClassFixture<CommonTestFixture>
    {
        [Theory]
        // [InlineData("Test Testoğlu")] //hersey doğru burada testi geçemez
        [InlineData("")]
        [InlineData("-1")]
        [InlineData("Tes")] //name'e min 4 harf girilicek demiştik o yüzden burada patlar
        public void WhenInvalidInputsGiven_Validator_ShouldBeReturnExceptions(string nameAndSurname)
        {
            //arrange
            CreateAuthorCommand command = new(null); //! burada context'i boş verebiliriz çünkü validator kısmına bakacağız zaten
            command.MyCreateModel = new()
            {
                NameAndSurname = nameAndSurname,
                //datetime istisna
                BirthOfDate = System.DateTime.Now.Date.AddYears(-1)
            };
            //act
            CreateAuthorCommandValidator validator = new();
            var result = validator.Validate(command);
            //assert
            result.Errors.Count.Should().BeGreaterThan(0);
        }

        [Fact]
        public void WhenDateTimeIsEqualNow_Validator_ShouldBeReturnException()
        {
            CreateAuthorCommand command = new CreateAuthorCommand(null);
            command.MyCreateModel = new CreateAuthorModel()
            {
                NameAndSurname = "Test Testoğlu",
                BirthOfDate = System.DateTime.Now.Date
            };
            CreateAuthorCommandValidator validator = new();
            var result = validator.Validate(command);
            result.Errors.Count.Should().BeGreaterThan(0);
            //datetime hatası olduğunda 1 hata döndürmesi gerekiyor ama 0 dödürüyor çözdüm 
            //validatordeki hatadan kaynaklıymış hata ise sonra date koymamışım 
        }

        [Fact]
        public void WhenInputsAreGiven_Validator_ShouldntBeReturnException() //HappyPath
        {
            CreateAuthorCommand command = new CreateAuthorCommand(null);
            command.MyCreateModel = new CreateAuthorModel()
            {
                NameAndSurname = "Test Testoğlu",
                BirthOfDate = System.DateTime.Now.Date.AddYears(-1)
            };
            CreateAuthorCommandValidator validator = new();
            var result = validator.Validate(command);
            result.Errors.Count.Should().Be(0);
        }
    }
}

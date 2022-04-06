using FluentValidation;

namespace webAPI.Applicaton.BookOperations.Commands.DeleteBook
{
    public class DeleteBookValidator : AbstractValidator<DeleteBookCommand>
    {
        public DeleteBookValidator()
        {
            RuleFor(x => x.MyBook.bookId).LessThan(0).WithMessage("ID sıfırdan küçük olamaz.");
        }
    }
}

using FluentValidation;

namespace webAPI.Applicaton.BookOperations.Commands.CreateBook
{
    public class CreateBookValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookValidator()
        {
            RuleFor(book => book.MyCreateModel.bookTitle)
                .NotEmpty()
                .WithMessage("Booktitle null olamaz.");
            RuleFor(book => book.MyCreateModel.bookPage)
                .GreaterThan(0)
                .WithMessage("Sayfa sayisi 0 olamaz.");
            RuleFor(book => book.MyCreateModel.bookRelase.Date)
                .NotEmpty()
                .LessThan(DateTime.Now.Date)
                .WithMessage("RelaseDate bugünden küçük olmalıdır.");
            RuleFor(book => book.MyCreateModel.authorId).LessThan(0).WithMessage("0dan küçük");
        }
    }
}

using FluentValidation;

namespace webAPI.Applicaton.BookOperations.Commands.UpdateBook
{
    public class UpdateBookValidator : AbstractValidator<UpdateBookQuery>
    {
        public UpdateBookValidator()
        {
            RuleFor(x => x.MyModel.bookTitle).NotEmpty().WithMessage("Title boş olamaz!");
            RuleFor(x => x.MyModel.authorId).LessThanOrEqualTo(0).WithMessage("0dan küçük olamaz");
        }
    }
}

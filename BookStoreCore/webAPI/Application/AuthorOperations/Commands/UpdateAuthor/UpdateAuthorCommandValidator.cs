using FluentValidation;

namespace webAPI.Application.AuthorOperations.Commands.UpdateAuthor
{
    public class UpdateAuthorCommandValidator : AbstractValidator<UpdateAuthorCommand>
    {
        public UpdateAuthorCommandValidator()
        {
            RuleFor(x => x.MyModel.DateOfBirth)
                .LessThan(DateTime.Now.Date)
                .WithMessage("Günümüzden büyük veya eşit olamaz!");
        }
    }
}

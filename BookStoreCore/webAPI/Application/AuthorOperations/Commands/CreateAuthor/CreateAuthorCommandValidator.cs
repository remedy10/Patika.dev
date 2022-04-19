using FluentValidation;

namespace webAPI.Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator()
        {
            RuleFor(x => x.MyCreateModel.NameAndSurname)
                .NotNull()
                .MinimumLength(4)
                .WithMessage("İsim-Soyisim boş olamaz");
            RuleFor(x => x.MyCreateModel.BirthOfDate.Date)
                .LessThan(DateTime.Now.Date)
                .WithMessage("Yazar bu sene mi doğdu?");
        }
    }
}

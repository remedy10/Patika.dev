using FluentValidation;

namespace webAPI.Application.AuthorOperations.Commands.CreateAuthor
{
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator()
        {
            RuleFor(x => x.MyCreateModel.NameAndSurname)
                .NotNull()
                .WithMessage("İsim-Soyisim boş olamaz");
            RuleFor(x => x.MyCreateModel.BirthOfDate)
                .LessThan(DateTime.Now)
                .WithMessage("Yazar bu sene mi doğdu?");
        }
    }
}

using FluentValidation;

namespace webAPI.Application.GenreOperations.Commands.CreateGenre
{
    public class CreateGenreValidator : AbstractValidator<CreateGenreCommand>
    {
        public CreateGenreValidator()
        {
            RuleFor(genre => genre.MyCreateModel.Name)
                .NotEmpty()
                .WithMessage("Genre adi boş olamaz.");
        }
    }
}

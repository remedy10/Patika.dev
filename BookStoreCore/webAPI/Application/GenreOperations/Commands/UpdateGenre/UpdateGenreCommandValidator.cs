using FluentValidation;

namespace webAPI.Application.GenreOperations.Commands.UpdateGenre
{
    public class UpdateGenreCommandValidator : AbstractValidator<UpdateGenreCommand>
    {
        public UpdateGenreCommandValidator()
        {
            RuleFor(x => x.UpdateModel.Name)
                .MinimumLength(4)
                .When(x => x.UpdateModel.Name.Trim() != string.Empty);
        }
    }
}

using FluentValidation;

namespace webAPI.Application.GenreOperations.Commands.DeleteGenre
{
    public class DeleteGenreValidator : AbstractValidator<DeleteGenreCommand>
    {
        public DeleteGenreValidator()
        {
            RuleFor(x => x.DeleteModel.Id).LessThan(0).WithMessage("ID sıfırdan küçük olamaz.");
        }
    }
}

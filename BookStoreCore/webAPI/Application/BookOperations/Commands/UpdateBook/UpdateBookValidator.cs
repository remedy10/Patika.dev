using FluentValidation;

namespace webAPI.Applicaton.BookOperations.Commands.UpdateBook
{
    public class UpdateBookValidator : AbstractValidator<UpdateBookQuery>
    {
        public UpdateBookValidator()
        {
            RuleFor(x => x.MyModel.bookTitle).NotEmpty().WithMessage("Title boş olamaz!");
            RuleFor(x => x.MyModel.genreId).IsInEnum().WithMessage("Böyle bir Genre yok!");
        }
    }
}

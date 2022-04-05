using FluentValidation;
using static webAPI.Models.UpdateBook.UpdateBook;

namespace webAPI.Models.UpdateBook
{
    public class UpdateBookValidator : AbstractValidator<UpdateBook>
    {
        public UpdateBookValidator()
        {
            RuleFor(x => x.MyModel.bookTitle).NotEmpty().WithMessage("Title boş olamaz!");
            RuleFor(x => x.MyModel.genreId).IsInEnum().WithMessage("Böyle bir Genre yok!");
        }
    }
}

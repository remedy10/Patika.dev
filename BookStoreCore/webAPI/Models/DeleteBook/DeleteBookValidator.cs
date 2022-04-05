using FluentValidation;


namespace webAPI.Models.DeleteBook
{
    public class DeleteBookValidator:AbstractValidator<DeleteBook>
    {
        public DeleteBookValidator()
        {
            RuleFor(x=>x.MyBook.bookId).LessThan(0).WithMessage("ID 0dan küçük olamaz ");
        }
        
    }
}
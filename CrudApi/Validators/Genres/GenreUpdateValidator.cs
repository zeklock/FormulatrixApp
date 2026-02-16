using CrudApi.Dtos.Genres;
using FluentValidation;

namespace CrudApi.Validators.Genres;

public class GenreUpdateValidator : AbstractValidator<GenreUpdateDto>
{
    public GenreUpdateValidator()
    {
        RuleFor(g => g.Name)
            .NotEmpty().WithMessage("Name is required.");
    }
}

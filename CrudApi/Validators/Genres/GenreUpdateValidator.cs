using CrudApi.Dtos.Genres;
using FluentValidation;

namespace CrudApi.Validators.Genres;

public class GenreUpdateValidator : AbstractValidator<GenreUpdateRequestDto>
{
    public GenreUpdateValidator()
    {
        RuleFor(g => g.Name)
            .NotEmpty().WithMessage("Name is required.");
    }
}

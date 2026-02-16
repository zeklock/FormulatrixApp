using CrudApi.Dtos.Genres;
using FluentValidation;

namespace CrudApi.Validators.Genres;

public class GenreCreateValidator : AbstractValidator<GenreCreateDto>
{
    public GenreCreateValidator()
    {
        RuleFor(g => g.Name)
            .NotEmpty().WithMessage("Name is required.");
    }
}

using CrudApi.Dtos.Games;
using CrudApi.Interfaces;
using FluentValidation;

namespace CrudApi.Validators.Games;

public class GameCreateValidator : AbstractValidator<GameCreateDto>
{
    public GameCreateValidator()
    {
        RuleFor(g => g.Title)
            .NotEmpty().WithMessage("Title is required.");

        RuleFor(g => g.ReleaseYear)
            .NotEmpty().WithMessage("Release year is required.")
            .InclusiveBetween(1900, DateTime.Now.Year).WithMessage("Release year must be between 1900 and current year.");
    }
}

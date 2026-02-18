using CrudApi.Dtos;
using CrudApi.Dtos.Genres;
using CrudApi.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CrudApi.Controllers;

[Authorize]
[ApiController]
[Route("/api/genres")]
public class GenreController : ControllerBase
{
    private readonly IGenreService _service;
    private readonly IValidator<GenreCreateRequestDto> _genreCreateDtoValidator;
    private readonly IValidator<GenreUpdateRequestDto> _genreUpdateDtoValidator;

    public GenreController(
        IGenreService service,
        IValidator<GenreCreateRequestDto> genreCreateDtoValidator,
        IValidator<GenreUpdateRequestDto> genreUpdateDtoValidator
    )
    {
        _service = service;
        _genreCreateDtoValidator = genreCreateDtoValidator;
        _genreUpdateDtoValidator = genreUpdateDtoValidator;
    }

    [HttpGet()]
    [SwaggerOperation(Summary = "Get all genres")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAll([FromQuery] GenreRequestDto request)
    {
        var response = await _service.GetAllAsync(request);

        if (!response.Success)
            return NotFound(response);

        return Ok(response);
    }

    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Get genre by id")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(Guid id)
    {
        var response = await _service.GetByIdAsync(id);

        if (!response.Success)
            return NotFound(response);

        return Ok(response);
    }

    [HttpPost()]
    [SwaggerOperation(Summary = "Create genre")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Create([FromBody] GenreCreateRequestDto genreCreateDto)
    {
        var validationResult = await _genreCreateDtoValidator.ValidateAsync(genreCreateDto);

        if (!validationResult.IsValid)
        {
            var validatorErrors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            var validatorResponse = ApiResponseDto<GenreCreateRequestDto>.ErrorResponse("Invalid input.", validatorErrors);
            return BadRequest(validatorResponse);
        }

        var response = await _service.CreateAsync(genreCreateDto);

        if (!response.Success)
            return NotFound(response);

        return Created($"/api/genres/{response.Data?.Id}", response);
    }

    [HttpPut("{id}")]
    [SwaggerOperation(Summary = "Update genre")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, [FromBody] GenreUpdateRequestDto genreUpdateDto)
    {
        var validationResult = await _genreUpdateDtoValidator.ValidateAsync(genreUpdateDto);

        if (!validationResult.IsValid)
        {
            var validatorErrors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            var validatorResponse = ApiResponseDto<GenreUpdateRequestDto>.ErrorResponse("Invalid input.", validatorErrors);
            return BadRequest(validatorResponse);
        }

        var response = await _service.UpdateAsync(id, genreUpdateDto);

        if (!response.Success)
            return NotFound(response);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    [SwaggerOperation(Summary = "Delete genre")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Delete(Guid id)
    {
        var response = await _service.DeleteAsync(id);

        if (!response.Success)
            return NotFound(response);

        return Ok(response);
    }
}

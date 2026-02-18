using CrudApi.Dtos;
using CrudApi.Dtos.Games;
using CrudApi.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace CrudApi.Controllers;

[Authorize]
[ApiController]
[Route("/api/games")]
public class GameController : ControllerBase
{
    private readonly IGameService _service;
    private readonly IValidator<GameCreateRequestDto> _gameCreateDtoValidator;
    private readonly IValidator<GameUpdateRequestDto> _gameUpdateDtoValidator;

    public GameController(
        IGameService service,
        IValidator<GameCreateRequestDto> gameCreateDtoValidator,
        IValidator<GameUpdateRequestDto> gameUpdateDtoValidator
    )
    {
        _service = service;
        _gameCreateDtoValidator = gameCreateDtoValidator;
        _gameUpdateDtoValidator = gameUpdateDtoValidator;
    }

    [HttpGet]
    [SwaggerOperation(Summary = "Get all games")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetAll([FromQuery] GameRequestDto request)
    {
        var response = await _service.GetAllAsync(request);

        if (!response.Success)
            return NotFound(response);

        return Ok(response);
    }

    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Get game by id")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Get(Guid id)
    {
        var response = await _service.GetByIdAsync(id);

        if (!response.Success)
            return NotFound(response);

        return Ok(response);
    }

    [HttpPost]
    [SwaggerOperation(Summary = "Create game")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Create([FromBody] GameCreateRequestDto gameCreateDto)
    {
        var validationResult = await _gameCreateDtoValidator.ValidateAsync(gameCreateDto);

        if (!validationResult.IsValid)
        {
            var validatorErrors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            var validatorResponse = ApiResponseDto<GameCreateRequestDto>.ErrorResponse("Invalid input.", validatorErrors);
            return BadRequest(validatorResponse);
        }

        var response = await _service.CreateAsync(gameCreateDto);

        if (!response.Success)
            return NotFound(response);

        return Created($"/api/games/{response.Data?.Id}", response);
    }

    [HttpPut("{id}")]
    [SwaggerOperation(Summary = "Update game")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> Update(Guid id, [FromBody] GameUpdateRequestDto gameUpdateDto)
    {
        var validationResult = await _gameUpdateDtoValidator.ValidateAsync(gameUpdateDto);

        if (!validationResult.IsValid)
        {
            var validatorErrors = validationResult.Errors.Select(e => e.ErrorMessage).ToList();
            var validatorResponse = ApiResponseDto<GameUpdateRequestDto>.ErrorResponse("Invalid input.", validatorErrors);
            return BadRequest(validatorResponse);
        }

        var response = await _service.UpdateAsync(id, gameUpdateDto);

        if (!response.Success)
            return NotFound(response);

        return Ok(response);
    }

    [HttpDelete("{id}")]
    [SwaggerOperation(Summary = "Delete game")]
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

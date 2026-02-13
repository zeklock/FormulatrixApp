using CrudApi.Dtos.Games;
using CrudApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CrudApi.Controllers;

[ApiController]
[Route("/api/games")]
public class GameController : ControllerBase
{
    private readonly IGameService _service;

    public GameController(IGameService service)
    {
        _service = service;
    }

    [HttpGet()]
    public async Task<IActionResult> GetAll()
    {
        var result = await _service.GetAllGamesAsync();

        if (!result.IsSuccess)
            return NotFound("No games found.");

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var result = await _service.GetGameByIdAsync(id);

        if (!result.IsSuccess)
            return NotFound("No games found.");

        return Ok(result);
    }

    [HttpPost()]
    public async Task<IActionResult> Create(GameCreateDto gameCreateDto)
    {
        try
        {
            var result = await _service.CreateGameAsync(gameCreateDto);

            if (!result.IsSuccess)
                return BadRequest(result.ErrorMessage);

            return Created($"/api/games/{result.Data?.Id}", result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, GameUpdateDto gameUpdateDto)
    {
        try
        {
            var result = await _service.UpdateGameAsync(id, gameUpdateDto);

            if (!result.IsSuccess)
                return NotFound("No games found.");

            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        try
        {
            var result = await _service.DeleteGameAsync(id);

            if (!result.IsSuccess)
                return NotFound("No games found.");

            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}

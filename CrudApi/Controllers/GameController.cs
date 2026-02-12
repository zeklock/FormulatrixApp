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
    public IActionResult GetAllGames()
    {
        var result = _service.GetAllGames();

        if (!result.IsSuccess)
            return NotFound();

        return Ok(result);
    }

    [HttpGet("{id}")]
    public IActionResult GetGameById(Guid id)
    {
        var result = _service.GetGameById(id);

        if (!result.IsSuccess)
            return NotFound();

        return Ok(result);
    }

    [HttpPost()]
    public IActionResult CreateGame(CreateGameDto createGameDto)
    {
        var result = _service.CreateGame(createGameDto);

        if (!result.IsSuccess)
            return BadRequest(result.ErrorMessage);

        return Created($"/api/games/{result.Data?.Id}", result);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateGame(Guid id, UpdateGameDto updateGameDto)
    {
        var result = _service.UpdateGame(id, updateGameDto);

        if (!result.IsSuccess)
            return NotFound();

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteGame(Guid id)
    {
        var result = _service.DeleteGame(id);

        if (!result.IsSuccess)
            return NotFound();

        return NoContent();
    }
}

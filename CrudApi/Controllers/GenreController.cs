using CrudApi.Dtos.Genres;
using CrudApi.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CrudApi.Controllers;

[ApiController]
[Route("/api/genres")]
public class GenreController : ControllerBase
{
    private readonly IGenreService _service;

    public GenreController(IGenreService service)
    {
        _service = service;
    }

    [HttpGet()]
    public IActionResult GetAllGenres()
    {
        var result = _service.GetAllGenres();

        if (!result.IsSuccess)
            return NotFound();

        return Ok(result);
    }

    [HttpGet("{id}")]
    public IActionResult GetGenreById(Guid id)
    {
        var result = _service.GetGenreById(id);

        if (!result.IsSuccess)
            return NotFound();

        return Ok(result);
    }

    [HttpPost()]
    public IActionResult CreateGenre(CreateGenreDto createGenreDto)
    {
        var result = _service.CreateGenre(createGenreDto);

        if (!result.IsSuccess)
            return BadRequest(result.ErrorMessage);

        return Created($"/api/genres/{result.Data?.Id}", result);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateGenre(Guid id, UpdateGenreDto updateGenreDto)
    {
        var result = _service.UpdateGenre(id, updateGenreDto);

        if (!result.IsSuccess)
            return NotFound();

        return Ok(result);
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteGenre(Guid id)
    {
        var result = _service.DeleteGenre(id);

        if (!result.IsSuccess)
            return NotFound();

        return NoContent();
    }
}

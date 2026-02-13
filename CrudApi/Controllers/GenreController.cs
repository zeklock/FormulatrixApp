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
    public async Task<IActionResult> GetAll()
    {
        var result = await _service.GetAllGenresAsync();

        if (!result.IsSuccess)
            return NotFound("No genres found.");

        return Ok(result);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var result = await _service.GetGenreByIdAsync(id);

        if (!result.IsSuccess)
            return NotFound("No genres found.");

        return Ok(result);
    }

    [HttpPost()]
    public async Task<IActionResult> Create(GenreCreateDto genreCreateDto)
    {
        try
        {
            var result = await _service.CreateGenreAsync(genreCreateDto);

            if (!result.IsSuccess)
                return BadRequest(result.ErrorMessage);

            return Created($"/api/genres/{result.Data?.Id}", result);
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(Guid id, GenreUpdateDto genreUpdateDto)
    {
        try
        {
            var result = await _service.UpdateGenreAsync(id, genreUpdateDto);

            if (!result.IsSuccess)
                return NotFound("No genres found.");

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
            var result = await _service.DeleteGenreAsync(id);

            if (!result.IsSuccess)
                return NotFound("No genres found.");

            return NoContent();
        }
        catch (Exception ex)
        {
            return BadRequest(ex.Message);
        }
    }
}

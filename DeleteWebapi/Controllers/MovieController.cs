using Microsoft.AspNetCore.Mvc;
using DeleteWebapi.Model;
using DeleteWebapi.Data;
namespace DeleteWebapi.Controllers{
[ApiController]
public class DeleteMovieController : ControllerBase
{
    private readonly AppDbContext _context;
    public DeleteMovieController(AppDbContext context)
    {
        _context = context;
    }
    [Route("api/DeleteMovie/{id}")]
    [HttpDelete]
    public async Task<IActionResult> DeleteMovie(int id)
    {
        if (id < 1)
            return BadRequest();
        var movieDetails = await _context.MovieDetails.FindAsync(id);
        if (movieDetails == null)
            return NotFound();
        _context.MovieDetails.Remove(movieDetails);
        await _context.SaveChangesAsync();
        return Ok();
    }

}
}
using Microsoft.AspNetCore.Mvc;
using UpdateWebapi.Model;
using UpdateWebapi.Data;
using Microsoft.EntityFrameworkCore;
namespace UpdateWebapi.Controllers{
[ApiController]
public class UpdateMovieController : ControllerBase
{
    private readonly AppDbContext _context;
    public UpdateMovieController(AppDbContext context)
    {
        _context = context;
    }
    [Route("api/UpdateMovie")]
    [HttpPut]
    public async Task<IActionResult> UpdateMovie(MovieDetails movieDetails)
    {
        if (movieDetails == null || movieDetails.MovieId == 0)
            return BadRequest();

       
        _context.Entry(movieDetails).State=EntityState.Modified;
        await _context.SaveChangesAsync();
        return Ok();
       }
}
}

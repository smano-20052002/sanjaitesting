using Microsoft.AspNetCore.Mvc;
using CreateWebapi.Data;
using CreateWebapi.Model;
using Microsoft.EntityFrameworkCore;
namespace CreateWebapi.Controllers{
[ApiController]

  public class AddMovieController : ControllerBase{
      private readonly AppDbContext context;
        public AddMovieController(AppDbContext context){
            this.context=context; 
        }
    [Route("api/AddMovie")]
     [HttpPost]
    public async Task<IActionResult> Post(MovieDetails movieDetails)
    {
        context.Add(movieDetails);
        await context.SaveChangesAsync();
        return Ok();
    }

  }
}
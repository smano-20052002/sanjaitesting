using Microsoft.EntityFrameworkCore;
using DeleteWebapi.Model;
namespace DeleteWebapi.Data{
public class AppDbContext:DbContext{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    public DbSet<MovieDetails> MovieDetails{get; set;}
    
}
}
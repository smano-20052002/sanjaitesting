using Microsoft.EntityFrameworkCore;
using CreateWebapi.Model;
namespace CreateWebapi.Data{

public class AppDbContext:DbContext{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    public DbSet<MovieDetails> MovieDetails{get; set;}
    
}
}
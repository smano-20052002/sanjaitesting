using Microsoft.EntityFrameworkCore;
using UpdateWebapi.Model;
namespace UpdateWebapi.Data{

public class AppDbContext:DbContext{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
    public DbSet<MovieDetails> MovieDetails{get; set;}
    
}
}
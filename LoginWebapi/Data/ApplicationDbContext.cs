using Microsoft.EntityFrameworkCore;
using LoginWebapi.Model;
namespace LoginWebapi.Data{

public class AppDbContext:DbContext{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
        
    }
   
    public DbSet<UserLogin> UserLogin{get; set;}
    
}
}
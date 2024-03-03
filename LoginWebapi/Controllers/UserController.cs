using Microsoft.AspNetCore.Mvc;
using LoginWebapi.Data;
using LoginWebapi.Model;
using Microsoft.EntityFrameworkCore;
namespace LoginWebapi.Controller
{
  [ApiController]

  public class UserController : ControllerBase
  {
    private readonly AppDbContext _context;
    public UserController(AppDbContext context)
    {
      _context = context;

    }
    [Route("api/Register")]
    [HttpPost]
    public async Task<IActionResult> Post(UserLogin userRegister){
      UserLogin olduser = _context.UserLogin.Find(userRegister.UserEmail);
      if(olduser == null){
        _context.UserLogin.Add(userRegister);
        await _context.SaveChangesAsync();
        return Ok("{\"Exists\":false}");
      }
      return Ok("{\"Exists\":true}");
      
      

    }
    [Route("api/CheckLogin")]
    [HttpPost]
    public async Task<IActionResult> Login(LoginDetails user)
    {
      UserLogin olduser = _context.UserLogin.Find(user.UserEmail);

      if (olduser.UserEmail == user.UserEmail && olduser != null)
      {
        if (olduser.UserPassword == user.UserPassword)
        {
          return Ok("{\"account\":true,\"emailstatus\":true,\"passwordstatus\":true,\"usernamer\":\"" + olduser.UserName + "\"}");
        }
        return Ok("{\"account\":true,\"emailstatus\":true,\"passwordstatus\":false}");
      }
      return Ok("{\"account\":false,\"emailstatus\":false,\"passwordstatus\":false}");
    }

  }
}
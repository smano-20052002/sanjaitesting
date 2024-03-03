using System.ComponentModel.DataAnnotations;

namespace LoginWebapi.Model{
public class UserLogin{
    [Key]
    public string? UserEmail{get;set;}
    [Required]
    public string? UserPassword{get;set;}
    [Required]
    public string? UserName{get;set;}
}
// just the class for validation check 
public class LoginDetails{
    public string? UserEmail{get;set;}
    public string? UserPassword{get;set;}
}

}
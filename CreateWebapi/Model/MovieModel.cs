using System.ComponentModel.DataAnnotations;

namespace CreateWebapi.Model{
public class MovieDetails{
    [Key] 
    public int MovieId{get;set;} 
    [Required]
    public string? MovieName{get;set;}
    [Required]
     public string? MovieType{get;set;}
     [Required]
    public string? MovieLanguage{get;set;}
    [Required]
    public string? MovieDurations{get;set;}
}
}
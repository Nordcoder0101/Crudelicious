using System.ComponentModel.DataAnnotations;
namespace Crudelicious.Models
{
  public class Dishes
  {
    [Key]
    public int Id {get;set;}
    [Required]
    [MinLength(3)]
    public string Name {get;set;}
    [Required]
    [MinLength(3)]
    public string Chef {get;set;}
    public int Tastiness {get;set;}
    [Required]
    public int Calories {get; set;}
    [Required]
    [MinLength(10)]
    public string Description {get;set;}

    public Dishes(){}
  }
}
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace DogDojo.Models
{
  public class Dog
  {
    public int DogId { get; set; }

    public string Name { get; set; }

    public int Age { get; set; }

    public string Sex { get; set; }

    public string Size { get; set; }

    public string Description { get; set; }

    [Column(TypeName = "decimal(18, 2)")]
    public decimal Price { get; set; }

    public string ImageUrl { get; set; }

    public bool IsDogOfTheWeek { get; set; }

    public bool IsAvailable { get; set; }

    public int BreedId { get; set; }

    public Breed Breed { get; set; }

    public string Notes { get; set; }
  }
}

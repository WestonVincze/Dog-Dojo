using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogDojo.Models
{
  public class Breed
  {
    public int BreedId { get; set; }

    public string BreedName { get; set; }

    public string Description { get; set; }

    public List<Dog> Dogs { get; set; }
  }
}

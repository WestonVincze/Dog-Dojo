using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogDojo.Models
{
  public interface IBreedRepository
  {
    IEnumerable<Breed> AllBreeds { get; }
  }
}

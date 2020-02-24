using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogDojo.Models
{
  public class MockBreedRepository : IBreedRepository
  {
    public IEnumerable<Breed> AllBreeds =>
      new List<Breed>
      {
        new Breed {BreedId=1, BreedName="Yellow Lab", Description="A yellow colored laborador."},
        new Breed {BreedId=2, BreedName="Black Lab", Description="A black colored laborador."},
        new Breed {BreedId=3, BreedName="Chocolate Lab", Description="A brown colored laborador."}
      };
  }
}

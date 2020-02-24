using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogDojo.Models
{
  public class BreedRepository : IBreedRepository
  {
    private readonly AppDbContext _appDbContext;
    
    public BreedRepository(AppDbContext appDbContext)
    {
      _appDbContext = appDbContext;
    }

    public IEnumerable<Breed> AllBreeds => _appDbContext.Breeds;
  }
}

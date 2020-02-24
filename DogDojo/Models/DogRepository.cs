using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogDojo.Models
{
  public class DogRepository : IDogRepository
  {
    private readonly AppDbContext _appDbContext;
    public DogRepository(AppDbContext appDbContext)
    {
      _appDbContext = appDbContext;
    }

    public IEnumerable<Dog> AllDogs
    {
      get
      {
        return _appDbContext.Dogs.Include(b => b.Breed);
      }
    }

    public IEnumerable<Dog> DogsOfTheWeek
    {
      get
      {
        return _appDbContext.Dogs.Include(b => b.Breed).Where(d => d.IsDogOfTheWeek);
      }
    }

    public Dog GetDogById(int dogId)
    {
      return _appDbContext.Dogs.FirstOrDefault(d => d.DogId == dogId);
    }
  }
}

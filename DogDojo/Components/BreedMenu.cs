using DogDojo.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogDojo.Components
{
  public class BreedMenu : ViewComponent
  {
    private readonly IBreedRepository _breedRepository;

    public BreedMenu(IBreedRepository breedRepository)
    {
      _breedRepository = breedRepository;
    }

    public IViewComponentResult Invoke()
    {
      var breeds = _breedRepository.AllBreeds.OrderBy(b => b.BreedName);
      return View(breeds);
    }
  }
}

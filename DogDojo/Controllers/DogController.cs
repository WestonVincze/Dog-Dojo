using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DogDojo.Models;
using DogDojo.ViewModels;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DogDojo.Controllers
{
  public class DogController : Controller
  {
    private readonly IDogRepository _dogRepository;
    private readonly IBreedRepository _breedRepository;

    public DogController(IDogRepository dogRepository, IBreedRepository breedRepositry)
    {
      _dogRepository = dogRepository;
      _breedRepository = breedRepositry;
    }

    public ViewResult List(string breed)
    {
      IEnumerable<Dog> dogs;
      string currentBreed;

      if (string.IsNullOrEmpty(breed))
      {
        dogs = _dogRepository.AllDogs.OrderBy(d => d.DogId);
        currentBreed = "All dogs";
      }
      else
      {
        dogs = _dogRepository.AllDogs.Where(d => d.Breed.BreedName == breed)
          .OrderBy(d => d.DogId);
        currentBreed = _breedRepository.AllBreeds.FirstOrDefault(b => b.BreedName == breed)?.BreedName;
      }

      return View(new DogListViewModel
      {
        Dogs = dogs,
        CurrentBreed = currentBreed
      });
    }

    public IActionResult Details(int id)
    {
      var dog = _dogRepository.GetDogById(id);
      if (dog == null)
        return NotFound();
      return View(dog);
    }
  }
}

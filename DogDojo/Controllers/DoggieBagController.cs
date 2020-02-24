using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DogDojo.Models;
using DogDojo.ViewModels;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DogDojo.Controllers
{
  public class DoggieBagController : Controller
  {
    private readonly IDogRepository _dogRepository;
    private readonly DoggieBag _doggieBag;

    public DoggieBagController(IDogRepository dogRepository, DoggieBag doggieBag)
    {
      _dogRepository = dogRepository;
      _doggieBag = doggieBag;
    }

    public IActionResult Index()
    {
      var items = _doggieBag.GetDoggieBagItems();
      _doggieBag.DoggieBagItems = items;

      var doggieBagViewModel = new DoggieBagViewModel
      {
        DoggieBag = _doggieBag,
        DoggieBagTotal = _doggieBag.GetDoggieBagTotal()
      };

      return View(doggieBagViewModel);
    }

    public RedirectToActionResult AddToDoggieBag(int dogId)
    {
      var selectedDog = _dogRepository.AllDogs.FirstOrDefault(d => d.DogId == dogId);

      if (selectedDog != null)
      {
        _doggieBag.AddToBag(selectedDog, 1);
      }

      return RedirectToAction("Index");
    }

    public RedirectToActionResult RemoveFromDoggieBag(int dogId)
    {
      var selectedDog = _dogRepository.AllDogs.FirstOrDefault(d => d.DogId == dogId);

      if (selectedDog != null)
      {
        _doggieBag.RemoveFromBag(selectedDog);
      }

      return RedirectToAction("Index");
    }
  }
}

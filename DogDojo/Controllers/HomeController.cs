using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DogDojo.Models;
using DogDojo.ViewModels;
using Microsoft.AspNetCore.Mvc;


namespace DogDojo.Controllers
{
  public class HomeController : Controller
  {
    private readonly IDogRepository _dogRepository;

    public HomeController(IDogRepository dogRepository)
    {
      _dogRepository = dogRepository;
    }

    public IActionResult Index()
    {
      var homeViewModel = new HomeViewModel
      {
        DogsOfTheWeek = _dogRepository.DogsOfTheWeek
      };

      return View(homeViewModel);
    }
  }
}

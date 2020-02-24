using DogDojo.Models;
using DogDojo.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogDojo.Components
{
  public class DoggieBagSummary : ViewComponent
  {
    private readonly DoggieBag _doggieBag;

    public DoggieBagSummary(DoggieBag doggieBag)
    {
      _doggieBag = doggieBag;
    }

    public IViewComponentResult Invoke()
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
  }
}

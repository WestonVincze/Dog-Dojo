using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;


namespace DogDojo.Controllers
{
  public class Contact : Controller
  {
    public IActionResult Index()
    {
      return View();
    }
  }
}

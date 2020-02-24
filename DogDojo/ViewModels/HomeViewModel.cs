using DogDojo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogDojo.ViewModels
{
  public class HomeViewModel
  {
    public IEnumerable<Dog> DogsOfTheWeek { get; set; }
  }
}


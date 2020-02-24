using DogDojo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogDojo.ViewModels
{
  public class DogListViewModel
  {
    public IEnumerable<Dog> Dogs { get; set; }

    public string CurrentBreed { get; set; }
  }
}

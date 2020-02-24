using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogDojo.Models
{
  public class DoggieBagItem
  {
    public int DoggieBagItemId { get; set; }

    public Dog Dog { get; set; }

    public int Amount { get; set; }

    public string DoggieBagId { get; set; }
  }
}

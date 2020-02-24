using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogDojo.Models
{
  public class DoggieBag
  {
    private readonly AppDbContext _appDbContext;

    public string DoggieBagId { get; set; }

    public List<DoggieBagItem> DoggieBagItems { get; set; }

    private DoggieBag(AppDbContext appDbContext)
    {
      _appDbContext = appDbContext;
    }

    public static DoggieBag GetBag(IServiceProvider services)
    {
      ISession session = services.GetRequiredService<IHttpContextAccessor>()?
          .HttpContext.Session;

      var context = services.GetService<AppDbContext>();

      string bagId = session.GetString("BagId") ?? Guid.NewGuid().ToString();

      session.SetString("BagId", bagId);

      return new DoggieBag(context) { DoggieBagId = bagId };
    }

    public void AddToBag(Dog dog, int amount)
    {
      var doggieBagItem =
              _appDbContext.DoggieBagItems.SingleOrDefault(
                  s => s.Dog.DogId == dog.DogId && s.DoggieBagId == DoggieBagId);

      if (doggieBagItem == null)
      {
        doggieBagItem = new DoggieBagItem
        {
          DoggieBagId = DoggieBagId,
          Dog = dog,
          Amount = 1
        };

        _appDbContext.DoggieBagItems.Add(doggieBagItem);
      }
      else
      {
        doggieBagItem.Amount++;
      }
      _appDbContext.SaveChanges();
    }

    public int RemoveFromBag(Dog dog)
    {
      var doggieBagItem =
              _appDbContext.DoggieBagItems.SingleOrDefault(
                  s => s.Dog.DogId == dog.DogId && s.DoggieBagId == DoggieBagId);

      var localAmount = 0;

      if (doggieBagItem != null)
      {
        if (doggieBagItem.Amount > 1)
        {
          doggieBagItem.Amount--;
          localAmount = doggieBagItem.Amount;
        }
        else
        {
          _appDbContext.DoggieBagItems.Remove(doggieBagItem);
        }
      }

      _appDbContext.SaveChanges();

      return localAmount;
    }

    public List<DoggieBagItem> GetDoggieBagItems()
    {
      return DoggieBagItems ??
             (DoggieBagItems =
                 _appDbContext.DoggieBagItems.Where(c => c.DoggieBagId == DoggieBagId)
                     .Include(s => s.Dog)
                     .ToList());
    }

    public void ClearBag()
    {
      var bagItems = _appDbContext
          .DoggieBagItems
          .Where(bag => bag.DoggieBagId == DoggieBagId);

      _appDbContext.DoggieBagItems.RemoveRange(bagItems);

      _appDbContext.SaveChanges();
    }

    public decimal GetDoggieBagTotal()
    {
      var total = _appDbContext.DoggieBagItems.Where(c => c.DoggieBagId == DoggieBagId)
          .Select(c => c.Dog.Price * c.Amount).Sum();
      return total;
    }
  }
}

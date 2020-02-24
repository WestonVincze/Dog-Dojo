using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogDojo.Models
{
  public class OrderRepository : IOrderRepository
  {
    private readonly AppDbContext _appDbContext;
    private readonly DoggieBag _doggieBag;

    public OrderRepository(AppDbContext appDbContext, DoggieBag doggieBag)
    {
      _appDbContext = appDbContext;
      _doggieBag = doggieBag;
    }
    public void CreateOrder(Order order)
    {
      order.OrderPlaced = DateTime.Now;

      var doggieBagItems = _doggieBag.DoggieBagItems;
      order.OrderTotal = _doggieBag.GetDoggieBagTotal();

      order.OrderDetails = new List<OrderDetail>();

      foreach (var doggieBagItem in doggieBagItems)
      {
        var OrderDetail = new OrderDetail()
        {
          Amount = doggieBagItem.Amount,
          DogId = doggieBagItem.Dog.DogId,
          OrderId = order.OrderId,
          Price = doggieBagItem.Dog.Price
        };

        order.OrderDetails.Add(OrderDetail);
      }

      _appDbContext.Orders.Add(order);

      _appDbContext.SaveChanges();
    }
  }
}

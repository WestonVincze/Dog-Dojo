using DogDojo.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DogDojo.Controllers
{
  [Authorize]
  public class OrderController : Controller
  {
    private readonly IOrderRepository _orderRepository;
    private readonly DoggieBag _doggieBag;

    public OrderController(IOrderRepository orderRepository, DoggieBag doggieBag)
    {
      _orderRepository = orderRepository;
      _doggieBag = doggieBag;
    }

    public IActionResult Checkout()
    {
      return View();
    }

    [HttpPost]
    public IActionResult Checkout(Order order)
    {
      var items = _doggieBag.GetDoggieBagItems();
      _doggieBag.DoggieBagItems = items;

      if (_doggieBag.DoggieBagItems.Count == 0)
      {
        ModelState.AddModelError("", "Your cart is empty, add some dogs first");
      }

      if (ModelState.IsValid)
      {
        _orderRepository.CreateOrder(order);
        _doggieBag.ClearBag();
        return RedirectToAction("CheckoutComplete");
      }

      return View(order);
    }

    public IActionResult CheckoutComplete()
    {
      ViewBag.CheckoutCompleteMessage = "Order Successful";

      return View();
    }
  }
}

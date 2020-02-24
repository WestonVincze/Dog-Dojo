﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DogDojo.Models
{
  public class Order
  {
    [BindNever]
    public int OrderId { get; set; }

    public List<OrderDetail> OrderDetails { get; set; }

    [Required(ErrorMessage = "Please enter your first name.")]
    [Display(Name = "First Name")]
    [StringLength(50)]
    public string FirstName { get; set; }

    [Required(ErrorMessage = "Please enter your last name.")]
    [Display(Name = "Last Name")]
    [StringLength(50)]
    public string LastName { get; set; }

    [Required(ErrorMessage = "Please enter your address.")]
    [StringLength(50)]
    public string Address { get; set; }

    [Required(ErrorMessage = "Please enter your postal code.")]
    [Display(Name = "Postal Code")]
    [StringLength(10, MinimumLength = 4)]
    public string PostalCode { get; set; }

    [Required(ErrorMessage = "Please enter your city.")]
    [StringLength(50)]
    public string City { get; set; }

    [Required(ErrorMessage = "Please enter your province.")]
    [StringLength(50)]
    public string Province { get; set; }

    [Required(ErrorMessage = "Please enter your country.")]
    [StringLength(50)]
    public string Country { get; set; }

    [Required(ErrorMessage = "Please enter your phone number.")]
    [StringLength(25)]
    [DataType(DataType.PhoneNumber)]
    [Display(Name = "Phone Number")]
    public string PhoneNumber { get; set; }

    [Required(ErrorMessage = "Please enter your email address.")]
    [StringLength(25)]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    [BindNever]
    [ScaffoldColumn(false)]
    public decimal OrderTotal { get; set; }

    [BindNever]
    [ScaffoldColumn(false)]
    public DateTime OrderPlaced { get; set; }
  }
}

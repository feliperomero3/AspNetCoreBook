using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SportsStore.Entities;

namespace SportsStore.Models;

public class OrderModel
{
    [BindNever]
    public long OrderID { get; set; }

    [BindNever]
    public ICollection<CartLine> Lines { get; set; } = new List<CartLine>();

    [Required(ErrorMessage = "Please enter a name")]
    public string Name { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please enter the first address line")]
    public string Line1 { get; set; } = string.Empty;

    public string Line2 { get; set; } = string.Empty;

    public string Line3 { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please enter a city name")]
    public string City { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please enter a state name")]
    public string State { get; set; } = string.Empty;

    public string Zip { get; set; } = string.Empty;

    [Required(ErrorMessage = "Please enter a country name")]
    public string Country { get; set; } = string.Empty;

    [DisplayName("Gift wrap these items")]
    public bool GiftWrap { get; set; }
}
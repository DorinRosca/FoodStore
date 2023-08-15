using FoodMarket.Pages.WishListItems.Entities;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodMarket.Pages.WishLists.Entities
{
     public class WishList
     {
          [Key]
          public int WishListId { get; set; }

          [Required]
          [ForeignKey(nameof(User))]
          public string UserId { get; set; }

          [Required, Range(0, double.MaxValue), Column(TypeName = "decimal(8,2)")]
          public double TotalAmount { get; set; }

          public IdentityUser User { get; set; }
          public ICollection<WishListItem> WishListItems { get; set; } = new List<WishListItem>();
     }
}

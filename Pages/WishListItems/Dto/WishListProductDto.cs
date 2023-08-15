using System.ComponentModel.DataAnnotations;

namespace FoodMarket.Pages.WishListItems.Dto
{
     public class WishListProductDto
     {
          [Required]
          public int Id { get; set; }
          [Required]
          public short Quantity { get; set; }
     }
}

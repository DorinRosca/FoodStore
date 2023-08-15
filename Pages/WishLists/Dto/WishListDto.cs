using FoodMarket.Pages.WishListItems.Entities;

namespace FoodMarket.Pages.WishLists.Dto
{
     public class WishListDto
     {
          public int WishListId { get; set; }

          public string UserId { get; set; }

          public double TotalAmount { get; set; }

          public ICollection<WishListItem> WishListItems { get; set; }
     }
}

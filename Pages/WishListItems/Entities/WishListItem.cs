using FoodMarket.Pages.Products.Entities;
using FoodMarket.Pages.WishLists.Entities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FoodMarket.Pages.WishListItems.Entities
{
     public class WishListItem
     {
          [Required]
          [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
          public int WishListItemId { get; set; }

          [Required]
          [ForeignKey(nameof(WishList))]
          public int WishListId { get; set; }

          [Required]
          [ForeignKey(nameof(Product))]
          public int ProductId { get; set; }

          [Required, Column(TypeName = "smallint")]
          [Range(1, short.MaxValue)]
          public short Quantity { get; set; }

          [Required, Range(0, double.MaxValue), Column(TypeName = "decimal(8,2)")]
          public double TotalAmount { get; set; }

          public Product Product { get; set; }

          [JsonIgnore]
          public WishList WishList { get; set; }
     }
}

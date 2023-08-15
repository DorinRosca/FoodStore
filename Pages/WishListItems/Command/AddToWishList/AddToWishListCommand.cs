using FoodMarket.Pages.WishListItems.Dto;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace FoodMarket.Pages.WishListItems.Command.AddToWishList
{
     public record AddToWishListCommand(WishListProductDto Model) : IRequest<bool>
     {
          [Required]
          public int Id { get; set; } = Model.Id;
          [Required]
          public short Quantity { get; set; } = Model.Quantity;
     }
}

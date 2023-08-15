using FoodMarket.Pages.WishListItems.Dto;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace FoodMarket.Pages.WishListItems.Command.DeleteFromWishList
{
     public record DeleteFromWishListCommand(WishListProductDto Model) : IRequest<bool>
     {
          [Required]
          public int Id { get; set; } = Model.Id;
          [Required]
          public short Quantity { get; set; } = Model.Quantity;
     }
}

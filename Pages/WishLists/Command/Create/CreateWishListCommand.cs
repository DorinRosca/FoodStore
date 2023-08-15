using MediatR;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FoodMarket.Pages.WishLists.Command.Create
{
     public record CreateWishListCommand(IdentityUser Model) : IRequest<bool>
     {
          [Required]
          public IdentityUser User { get; set; } = Model;



     }
}

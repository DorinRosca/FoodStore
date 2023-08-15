using FoodMarket.Pages.User.Dto;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace FoodMarket.Pages.User.Command.AddRole
{
     public record AddRoleCommand(RoleDto Model) : IRequest<bool>
     {

          [Required, StringLength(50)]
          public string Name { get; set; } = Model.Name;
          public string NormalizedName { get; set; } = Model.NormalizedName;

     }
}

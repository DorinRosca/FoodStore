using FoodMarket.Pages.User.Dto;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace FoodMarket.Pages.User.Command.SetRole
{
     public record SetRoleCommand(UserRoleDto Model) : IRequest<bool>
     {
          [Required, StringLength(50)] public string UserName { get; set; } = Model.UserName;
          [Required, StringLength(50)] public string RoleName { get; set; } = Model.RoleName;

     }
}

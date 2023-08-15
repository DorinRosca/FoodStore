using FoodMarket.Pages.User.Dto;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FoodMarket.Pages.User.Command.Login
{
     public record LoginUserCommand(LoginUser Model) : IRequest<object?>
     {
          [Required]
          [EmailAddress]
          public string Email = Model.Email;
          [Required]
          [DataType(DataType.Password)]

          public string Password = Model.Password;

          public bool RememberMe = Model.RememberMe;
     }
}

using FoodMarket.Pages.User.Dto;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace FoodMarket.Pages.User.Command.Register
{
     public record RegisterUserCommand(RegisterUser Model) : IRequest<IdentityResult>
     {
          [Required]
          [EmailAddress]
          public string Email { get; set; } = Model.Email;
          [Required]
          [DataType(DataType.Password)]
          public string Password { get; set; } = Model.Password;

          [DataType(DataType.Password)]
          [Display(Name = "Confirm Password")]
          [Compare("Password", ErrorMessage = "Password and confirmation password not match.")]
          public string ConfirmPassword { get; set; } = Model.ConfirmPassword;

     }
}

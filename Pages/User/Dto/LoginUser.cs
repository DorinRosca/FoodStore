using System.ComponentModel.DataAnnotations;

namespace FoodMarket.Pages.User.Dto
{
     public class LoginUser
     {
          [Required]
          [EmailAddress]
          public string Email { get; set; }
          [Required]
          [DataType(DataType.Password)]
          public string Password { get; set; }
          [Required]
          public bool RememberMe { get; set; }
     }
}

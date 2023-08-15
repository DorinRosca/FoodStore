using System.ComponentModel.DataAnnotations;

namespace FoodMarket.Pages.User.Dto
{
     public class UserRoleDto
     {
          [Required, StringLength(50)]

          public string UserName { get; set; }
          [Required, StringLength(50)]
          public string RoleName { get; set; }
     }
}

using System.ComponentModel.DataAnnotations;

namespace FoodMarket.Pages.User.Dto
{
     public class RoleDto
     {
          public string Id { get; set; }
          [StringLength(50)]

          public string NormalizedName { get; set; }
          [Required, StringLength(50)]
          public string Name { get; set; }
     }
}

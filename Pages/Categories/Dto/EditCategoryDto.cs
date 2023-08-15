using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodMarket.Pages.Categories.Dto
{
     public class EditCategoryDto
     {
          [Required, StringLength(50), Column(TypeName = "nvarchar(50)")]
          public string Name { get; set; }

          [Required, StringLength(50), Column(TypeName = "nvarchar(50)")]
          public string Description { get; set; }
     }
}

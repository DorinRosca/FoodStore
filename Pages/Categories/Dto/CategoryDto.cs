using FoodMarket.Pages.Products.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace FoodMarket.Pages.Categories.Dto
{
     public class CategoryDto
     {
          public int CategoryId { get; set; }


          [Required, StringLength(50), Column(TypeName = "nvarchar(50)")]
          public string Name { get; set; }

          [Required, StringLength(50), Column(TypeName = "nvarchar(50)")]
          public string Description { get; set; }
          [JsonIgnore]
          public ICollection<Product> Products { get; set; }


     }
}

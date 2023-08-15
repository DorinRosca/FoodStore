using FoodMarket.Pages.Products.Entities;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodMarket.Pages.Categories.Entities
{
     public class Category
     {
          [Key]
          [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
          public int CategoryId { get; set; }


          [Required, StringLength(50), Column(TypeName = "nvarchar(50)")]
          public string Name { get; set; }

          [Required, StringLength(50), Column(TypeName = "nvarchar(50)")]
          public string Description { get; set; }
          [System.Text.Json.Serialization.JsonIgnore]
          public ICollection<Product> Products { get; set; }


     }
}

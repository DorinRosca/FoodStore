using FoodMarket.Pages.Categories.Entities;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodMarket.Pages.Products.Dto
{
     public class ProductDto
     {
          public int ProductId { get; set; }

          [Required]
          public string ImageUrl { get; set; }

          [Required, StringLength(50), Column(TypeName = "nvarchar(50)")]
          public string Name { get; set; }


          [Required, StringLength(100), Column(TypeName = "nvarchar(100)")]
          public string Description { get; set; }


          [Required, Column(TypeName = "smallint")]
          [Range(0, short.MaxValue)]
          public short UnitPrice { get; set; }


          [Required]
          [Range(0, int.MaxValue)]
          public int CustomerPurchaseCount { get; set; }
          public ICollection<Category> Categories { get; set; }


     }
}

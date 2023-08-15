using FoodMarket.Pages.Products.Dto;
using MediatR;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodMarket.Pages.Products.Command.Create
{
     public record CreateProductCommand(CreateProductDto Model) : IRequest<bool>
     {

          [Required, StringLength(50), Column(TypeName = "nvarchar(50)")]
          public string ImageUrl { get; set; } = Model.ImageUrl;

          [Required, StringLength(50), Column(TypeName = "nvarchar(50)")]
          public string Name { get; set; } = Model.Name;

          [Required, Column(TypeName = "smallint")]
          public short UnitPrice { get; set; } = Model.UnitPrice;

          [Required, StringLength(100), Column(TypeName = "nvarchar(100)")]
          public string Description { get; set; } = Model.Description;


     }
}

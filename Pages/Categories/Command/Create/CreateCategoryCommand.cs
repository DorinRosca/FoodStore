using FoodMarket.Pages.Categories.Dto;
using MediatR;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodMarket.Pages.Categories.Command.Create
{
     public record CreateCategoryCommand(CreateCategoryDto Model) : IRequest<bool>
     {
          [Required, StringLength(50), Column(TypeName = "nvarchar(50)")]
          public string Name { get; set; } = Model.Name;

          [Required, StringLength(50), Column(TypeName = "nvarchar(50)")]
          public string Description { get; set; } = Model.Description;


     }
}

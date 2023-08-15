using FoodMarket.Pages.Categories.Dto;
using MediatR;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FoodMarket.Pages.Categories.Command.Edit
{
     public record EditCategoryCommand(int Id, EditCategoryDto Model) : IRequest<bool>
     {
          public int CategoryId { get; set; } = Id;

          [Required, StringLength(50), Column(TypeName = "nvarchar(50)")]
          public string Name { get; set; } = Model.Name;

          [Required, StringLength(50), Column(TypeName = "nvarchar(50)")]
          public string Description { get; set; } = Model.Description;

     }
}

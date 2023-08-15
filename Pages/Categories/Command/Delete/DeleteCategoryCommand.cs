using MediatR;

namespace FoodMarket.Pages.Categories.Command.Delete
{
     public record DeleteCategoryCommand(int Id) : IRequest<bool>
     {

          public int Id { get; set; } = Id;


     }
}

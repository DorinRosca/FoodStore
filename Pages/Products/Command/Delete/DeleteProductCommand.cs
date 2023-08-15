using MediatR;

namespace FoodMarket.Pages.Products.Command.Delete
{
     public record DeleteProductCommand(int Id) : IRequest<bool>
     {

          public int Id { get; set; } = Id;


     }
}

using MediatR;

namespace FoodMarket.Pages.User.Command.GetId
{
     public record GetIdCommand : IRequest<string?>;
}

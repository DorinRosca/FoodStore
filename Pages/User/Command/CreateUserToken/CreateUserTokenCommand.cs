using FoodMarket.Pages.User.Dto;
using MediatR;

namespace FoodMarket.Pages.User.Command.CreateUserToken
{
     public record CreateUserTokenCommand(LoginUser user, IList<string> roles) :IRequest<object?>
     {
          public LoginUser User { get; set; } = user;

          public IList<string> Roles { get; set; } = roles;
     }
}

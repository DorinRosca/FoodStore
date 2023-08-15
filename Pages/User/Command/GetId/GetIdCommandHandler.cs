using MediatR;
using System.Security.Claims;

namespace FoodMarket.Pages.User.Command.GetId
{

     public class GetIdCommandHandler : IRequestHandler<GetIdCommand, string?>
     {
          private readonly IHttpContextAccessor _httpContextAccessor;

          public GetIdCommandHandler(IHttpContextAccessor httpContextAccessor)
          {
               _httpContextAccessor = httpContextAccessor;
          }

          public Task<string?> Handle(GetIdCommand request, CancellationToken cancellationToken)
          {
               var claimsPrincipal = _httpContextAccessor.HttpContext?.User;

               if (claimsPrincipal?.Identity != null && claimsPrincipal.Identity.IsAuthenticated)
               {
                    var userIdClaim = claimsPrincipal.FindFirst(ClaimTypes.NameIdentifier);

                    if (userIdClaim != null)
                    {
                         return Task.FromResult(userIdClaim.Value);
                    }
               }
               return Task.FromResult<string?>(null);
          }
     }
}

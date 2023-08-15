using FoodMarket.Pages.WishLists.Command.Create;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace FoodMarket.Pages.User.Command.Register
{
     public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, IdentityResult>
     {
          private readonly UserManager<IdentityUser> _userManager;
          private readonly SignInManager<IdentityUser> _signInManager;
          private readonly IMediator _mediator;


          public RegisterUserCommandHandler(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager, IMediator mediator)
          {
               _userManager = userManager;
               _signInManager = signInManager;
               _mediator = mediator;
          }

          public async Task<IdentityResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
          {
               if (request == null)
               {
                    throw new ArgumentNullException(nameof(request), "There is no such model");
               }

               var user = new IdentityUser
               {
                    UserName = request.Email,
                    Email = request.Email,
               };

               var result = await _userManager.CreateAsync(user, request.Password);

               if (result.Succeeded)
               {
                    await _mediator.Send(new CreateWishListCommand(user), cancellationToken);
                    await _signInManager.SignInAsync(user, isPersistent: false);
               }

               return result;
          }

     }
}

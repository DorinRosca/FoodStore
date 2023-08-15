using AutoMapper;
using FoodMarket.Pages.User.Command.CreateUserToken;
using FoodMarket.Pages.User.Dto;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace FoodMarket.Pages.User.Command.Login
{
     public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, object?>
     {
          private readonly SignInManager<IdentityUser> _signInManager;
          private readonly UserManager<IdentityUser> _userManager;
          private readonly IMapper _mapper;
          private readonly IMediator _mediator;


          public LoginUserCommandHandler(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, IMapper mapper, IMediator mediator)
          {
               _signInManager = signInManager;
               _userManager = userManager;
               _mapper = mapper;
               _mediator = mediator;
          }

          public async Task<object?> Handle(LoginUserCommand request, CancellationToken cancellationToken)
          {
               var result = await _signInManager.PasswordSignInAsync(request.Email, request.Password, request.RememberMe, false);

               var identityUser = await _userManager.FindByNameAsync(request.Email);
               var userRoles = await _userManager.GetRolesAsync((identityUser));
               var user = _mapper.Map<LoginUser>(request);
               var tokenString = _mediator.Send(new CreateUserTokenCommand(user, userRoles),cancellationToken).Result;
               return tokenString;
          }
     }
}

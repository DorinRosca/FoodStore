using FoodMarket.Pages.User.Command.AddRole;
using FoodMarket.Pages.User.Command.Login;
using FoodMarket.Pages.User.Command.Register;
using FoodMarket.Pages.User.Command.SetRole;
using FoodMarket.Pages.User.Dto;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FoodMarket.Pages.User.Command.CreateUserToken;

namespace FoodMarket.Pages.User
{
     [Route("api/user")]
     [ApiController]
     public class UserController : ControllerBase
     {
          private readonly IMediator _mediator;

          public UserController(IMediator mediator)
          {
               _mediator = mediator;
          }
          /// <summary>
          /// login in system
          /// </summary>
          /// <param name="user"></param>
          /// <returns></returns>
          /// <response code="200">the user logged successfully and token was generated </response>
          /// <response code="500">login failed due to validation errors</response>
          [HttpPost("login")]
          public async Task<IActionResult> Login([FromBody] LoginUser user)
          {
               var result = await _mediator.Send(new LoginUserCommand(user));
               if (result != null)
               {
                    return Ok(result);
               }

               return Problem();
          }
          /// <summary>
          /// add a new role for users
          /// </summary>
          /// <param name="role"></param>
          /// <returns></returns>
          /// <response code="200">the role was successfully added in DBase </response>
          /// <response code="500">Unable to add role due to validation error</response>
          [HttpPost("role/add")]
          [Authorize(Roles = "Manager")]
          public async Task<IActionResult> AddRole([FromBody] RoleDto role)
          {
               var result = await _mediator.Send(new AddRoleCommand(role));
               if (result)
               {
                    return Ok(result);
               }

               return Problem();
          }
          /// <summary>
          /// assign a role to a user 
          /// </summary>
          /// <param name="userRole"></param>
          /// <returns></returns>
          /// <response code="200">the role was successfully assigned to user </response>
          /// <response code="400">Unable to assign role due to validation error</response>
          /// 
          [HttpPost("role/set")]
          [Authorize(Roles = "Manager")]

          public async Task<IActionResult> AddRole([FromBody] UserRoleDto userRole)
          {
               var result = await _mediator.Send(new SetRoleCommand(userRole));
               if (result)
               {
                    return Ok(result);
               }

               return Problem();
          }
          /// <summary>
          /// register a new user in system
          /// </summary>
          /// <param name="user"></param>
          /// <returns></returns>
          [HttpPost("register")]
          public async Task<IActionResult> Register([FromBody] RegisterUser user)
          {
               var products = await _mediator.Send(new RegisterUserCommand(user));
               return Ok(products);
          }

         
     }
}

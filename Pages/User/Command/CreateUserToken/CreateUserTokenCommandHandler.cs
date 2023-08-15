using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FoodMarket.Pages.User.Dto;
using MediatR;
using Microsoft.IdentityModel.Tokens;

namespace FoodMarket.Pages.User.Command.CreateUserToken
{
     public class CreateUserTokenCommandHandler :IRequestHandler<CreateUserTokenCommand, object?>
     {
          private readonly IConfiguration _configuration;

          public CreateUserTokenCommandHandler(IConfiguration configuration)
          {
               _configuration = configuration;
          }

          public async Task<object?> Handle(CreateUserTokenCommand request, CancellationToken cancellationToken)
          {
               var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));

               var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

               var claims = new List<Claim>()
               {
                    new Claim(ClaimTypes.Email, request.User.Email)
               };
               foreach (var role in request.roles)
               {
                    claims.Add(new Claim(ClaimTypes.Role, role));
               }

               var token = new JwtSecurityToken(_configuration["Jwt:Issuer"], _configuration["Jwt:Audience"], claims,
                    expires: DateTime.UtcNow.AddDays(1), signingCredentials: credentials);
                return Task.FromResult(new JwtSecurityTokenHandler().WriteToken(token)).Result;
          }
     }
}

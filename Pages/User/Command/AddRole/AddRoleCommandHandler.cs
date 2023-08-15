using AutoMapper;
using FoodMarket.Data;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace FoodMarket.Pages.User.Command.AddRole
{
     public class AddRoleCommandHandler : IRequestHandler<AddRoleCommand, bool>
     {
          private readonly DataContext _context;
          private readonly IMapper _mapper;

          public AddRoleCommandHandler(DataContext context, IMapper mapper)
          {
               _context = context;
               _mapper = mapper;
          }

          public async Task<bool> Handle(AddRoleCommand request, CancellationToken cancellationToken)
          {
               if (request == null)
               {
                    throw new ArgumentNullException(nameof(request), "Model cannot be null");
               }

               request.NormalizedName = request.Name;
               var entity = _mapper.Map<AddRoleCommand, IdentityRole>(request);
               entity.Id = Guid.NewGuid().ToString(); // Generate a new unique identifier for the Id
               await _context.Roles.AddAsync(entity, cancellationToken);
               var result = await _context.SaveChangesAsync(cancellationToken);
               return result > 0;
          }
     }
}

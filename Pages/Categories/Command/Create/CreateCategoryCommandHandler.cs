using AutoMapper;
using FoodMarket.Data;
using FoodMarket.Pages.Categories.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FoodMarket.Pages.Categories.Command.Create
{
     public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, bool>
     {
          private readonly DataContext _context;
          private readonly IMapper _mapper;
          public CreateCategoryCommandHandler(DataContext context, IMapper mapper)
          {
               _context = context;
               _mapper = mapper;
          }
          public async Task<bool> Handle(CreateCategoryCommand? request, CancellationToken cancellationToken)
          {
               if (request == null)
               {
                    return false;
               }

               if (!await CategoryExists(request))
               {
                    return false;
               }
               var category = _mapper.Map<Category>(request);
               await _context.Categories.AddAsync(category, cancellationToken);
               var result = await _context.SaveChangesAsync(cancellationToken);
               return result > 0;
          }

          public async Task<bool> CategoryExists(CreateCategoryCommand request)
          {
               var result = await _context.Categories.FirstOrDefaultAsync(c => c.Name == request.Name);
               if (result == null)
               {
                    return true;
               }
               return false;
          }
     }
}

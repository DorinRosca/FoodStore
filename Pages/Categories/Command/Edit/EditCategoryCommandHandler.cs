using AutoMapper;
using FoodMarket.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FoodMarket.Pages.Categories.Command.Edit
{
     public class EditCategoryCommandHandler : IRequestHandler<EditCategoryCommand, bool>
     {
          private readonly DataContext _context;
          private readonly IMapper _mapper;
          private readonly IMediator _mediator;

          public EditCategoryCommandHandler(DataContext context, IMapper mapper, IMediator mediator)
          {
               _context = context;
               _mapper = mapper;
               _mediator = mediator;
          }
          public async Task<bool> Handle(EditCategoryCommand request, CancellationToken cancellationToken)
          {
               if (request == null)
               {
                    return false;
               }

               var existingEntity = await _context.Categories.FirstOrDefaultAsync(c => c.CategoryId == request.Id, cancellationToken);

               if (existingEntity == null)
               {
                    return false;
               }

               _mapper.Map(request, existingEntity);

               _context.Categories.Update(existingEntity);

               var result = await _context.SaveChangesAsync(cancellationToken);
               return result > 0;
          }

     }
}

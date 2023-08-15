using AutoMapper;
using FoodMarket.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FoodMarket.Pages.Products.Command.Edit
{
     public class EditProductCommandHandler : IRequestHandler<EditProductCommand, bool>
     {
          private readonly DataContext _context;
          private readonly IMapper _mapper;

          public EditProductCommandHandler(DataContext context, IMapper mapper)
          {
               _context = context;
               _mapper = mapper;
          }
          public async Task<bool> Handle(EditProductCommand? request, CancellationToken cancellationToken)
          {
               if (request == null)
               {
                    return false;
               }
               var existingEntity = await _context.Products.FirstOrDefaultAsync(c => c.ProductId == request.Id, cancellationToken);

               if (existingEntity == null)
               {
                    return false;
               }

               _mapper.Map(request, existingEntity);

               _context.Products.Update(existingEntity);

               var result = await _context.SaveChangesAsync(cancellationToken);
               return result > 0;
          }
     }
}

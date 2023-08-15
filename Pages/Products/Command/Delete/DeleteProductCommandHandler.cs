using FoodMarket.Data;
using MediatR;

namespace FoodMarket.Pages.Products.Command.Delete
{
     public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand, bool>
     {
          private readonly DataContext _context;

          public DeleteProductCommandHandler(DataContext context)
          {
               _context = context;
          }
          public async Task<bool> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
          {
               if (request.Id <= 0)
               {
                    return false;
               }

               var entity = await _context.Products.FindAsync(request.Id, cancellationToken);
               if (entity == null)
               {
                    return false;

               }
               _context.Products.Remove(entity);

               var result = await _context.SaveChangesAsync(cancellationToken);
               return result > 0;
          }
     }
}

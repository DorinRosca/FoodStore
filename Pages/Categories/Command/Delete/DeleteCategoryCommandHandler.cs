using FoodMarket.Data;
using MediatR;

namespace FoodMarket.Pages.Categories.Command.Delete
{
     public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, bool>
     {
          private readonly DataContext _context;

          public DeleteCategoryCommandHandler(DataContext context)
          {
               _context = context;
          }
          public async Task<bool> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
          {
               if (request.Id <= 0)
               {
                    return false;
               }

               var entity = await _context.Categories.FindAsync(request.Id, cancellationToken);
               if (entity == null)
               {
                    return false;

               }
               _context.Categories.Remove(entity);

               var result = await _context.SaveChangesAsync(cancellationToken);
               return result > 0;
          }
     }
}

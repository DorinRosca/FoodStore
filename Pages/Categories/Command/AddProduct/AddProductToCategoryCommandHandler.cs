using FoodMarket.Data;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FoodMarket.Pages.Categories.Command.AddProduct
{
     public class AddProductToCategoryCommandHandler : IRequestHandler<AddProductToCategoryCommand, bool>
     {
          private readonly DataContext _context;

          public AddProductToCategoryCommandHandler(DataContext context)
          {
               _context = context;
          }
          public async Task<bool> Handle(AddProductToCategoryCommand request, CancellationToken cancellationToken)
          {
               var category = await _context.Categories.Where(c => c.CategoryId == request.CategoriesId)
                    .Include(c => c.Products)
                    .FirstOrDefaultAsync(cancellationToken: cancellationToken);
               if (category == null)
               {
                    return false;
               }
               var product = await _context.Products.FindAsync(request.ProductsId, cancellationToken);
               if (product == null)
               {
                    return false;
               }
               category.Products.Add(product);
               var result = await _context.SaveChangesAsync(cancellationToken);
               return result > 0;
          }
     }
}

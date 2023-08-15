using FoodMarket.Data;
using FoodMarket.Pages.User.Command.GetId;
using FoodMarket.Pages.WishListItems.Entities;
using FoodMarket.Pages.WishLists.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FoodMarket.Pages.WishListItems.Command.DeleteFromWishList
{
     public class DeleteFromWishListCommandHandler : IRequestHandler<DeleteFromWishListCommand, bool>
     {
          private readonly DataContext _context;
          private readonly string? _userId;

          public DeleteFromWishListCommandHandler(DataContext context, IMediator mediator)
          {
               _context = context;
               _userId = mediator.Send(new GetIdCommand()).Result;
          }

          public async Task<bool> Handle(DeleteFromWishListCommand request, CancellationToken cancellationToken)
          {
               if (_userId != null)
               {
                    var list = await _context.WishLists.FirstOrDefaultAsync(c => c.UserId == _userId,
                         cancellationToken);
                    var product =
                         await _context.Products.FirstOrDefaultAsync(c => c.ProductId == request.Id, cancellationToken);
                    var existItem = await _context.WishListItems.FirstOrDefaultAsync(
                         c => list != null && product != null && c.ProductId == product.ProductId && c.WishListId == list.WishListId, cancellationToken);
                    if (existItem != null &&request.Quantity <= existItem.Quantity)
                    {

                         return list != null && product != null && await UpdateItem(existItem, list, request.Quantity, product.UnitPrice);

                    }
               }

               return false;
          }
          public async Task<bool> UpdateItem(WishListItem item, WishList list, short quantity, short unitPrice)
          {
               item.Quantity -= quantity;
               item.TotalAmount -= quantity * unitPrice;
               list.TotalAmount -= quantity * unitPrice;
               if (item.TotalAmount < 0 || list.TotalAmount <0)
               {
                    return false;
               }
               else if (item.TotalAmount == 0)
               {
                    _context.WishListItems.Remove(item);
               }
               var result = await _context.SaveChangesAsync();
               return result > 0;
          }
     }
}

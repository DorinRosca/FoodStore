using FoodMarket.Data;
using FoodMarket.Pages.Products.Entities;
using FoodMarket.Pages.User.Command.GetId;
using FoodMarket.Pages.WishListItems.Entities;
using FoodMarket.Pages.WishLists.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace FoodMarket.Pages.WishListItems.Command.AddToWishList
{
     public class AddToWishListCommandHandler : IRequestHandler<AddToWishListCommand, bool>
     {
          private readonly DataContext _context;
          private readonly string? _userId;

          public AddToWishListCommandHandler(DataContext context, IMediator mediator)
          {
               _context = context;
               _userId = mediator.Send(new GetIdCommand()).Result;
          }

          public async Task<bool> Handle(AddToWishListCommand request, CancellationToken cancellationToken)
          {
               if (_userId.IsNullOrEmpty())
               {
                    return false;
               }
               else
               {
                    var list = await _context.WishLists.FirstOrDefaultAsync(c => c.UserId == _userId, cancellationToken);
                    var product =
                         await _context.Products.FirstOrDefaultAsync(c => c.ProductId == request.Id, cancellationToken);
                    var existItem = await _context.WishListItems.FirstOrDefaultAsync(
                         c => list != null && product != null && c.ProductId == product.ProductId && c.WishListId == list.WishListId, cancellationToken);
                    if (existItem != null && product != null)
                    {
                         var result = await UpdateItem(list, existItem, request, product);
                         return result;
                    }
                    else
                    {
                         var result = product != null && list != null && await CreateItem(list, request, product);
                         if (result)
                         {
                              if (product != null) await IncreasePurchaseCount(product);
                              return true;
                         }

                         return false;
                    }

               }
          }

          public async Task<bool> UpdateItem(WishList list, WishListItem item, AddToWishListCommand request, Product product)
          {
               item.Quantity += request.Quantity;
               item.TotalAmount += request.Quantity * product.UnitPrice;
               var totalAmount = product.UnitPrice * request.Quantity;
               if (list != null) list.TotalAmount += totalAmount;

               var result = await _context.SaveChangesAsync();
               return result > 0;
          }
          public async Task<bool> CreateItem(WishList list, AddToWishListCommand request, Product product)
          {
               var wishListItem = new WishListItem
               {
                    WishListId = list.WishListId,
                    ProductId = product.ProductId,
                    Quantity = request.Quantity,
                    TotalAmount = product.UnitPrice * request.Quantity
               };
               await _context.WishListItems.AddAsync(wishListItem);
               var totalAmount = product.UnitPrice * request.Quantity;
               var wishList =
                    await _context.WishLists.FirstOrDefaultAsync(c => c.UserId == _userId);
               if (wishList != null) wishList.TotalAmount += totalAmount;
               var result = await _context.SaveChangesAsync();
               return result > 0;
          }
          public async Task<Product> IncreasePurchaseCount(Product product)
          {
               product.CustomerPurchaseCount++;
               await _context.SaveChangesAsync();
               return product;
          }
     }
}

using AutoMapper;
using FoodMarket.Data;
using FoodMarket.Pages.User.Command.GetId;
using FoodMarket.Pages.WishLists.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FoodMarket.Pages.WishLists.Query.Get
{
     public class GetWishListQueryHandler : IRequestHandler<GetWishListQuery, WishListDto?>
     {
          private readonly DataContext _context;
          private readonly IMapper _mapper;
          private readonly string? _userId;

          public GetWishListQueryHandler(DataContext context, IMapper mapper, IMediator mediator)
          {
               _context = context;
               _mapper = mapper;
               _userId = mediator.Send(new GetIdCommand()).Result;
          }

          public async Task<WishListDto?> Handle(GetWishListQuery request, CancellationToken cancellationToken)
          {
               if (_userId != null)
               {

                    var wishList = await _context.WishLists
                         .Where(x => x.UserId == _userId)
                         .Include(x => x.WishListItems)
                         .FirstOrDefaultAsync(cancellationToken);

                    if (wishList != null)
                    {
                         return _mapper.Map<WishListDto>(wishList);
                    }
               }
               return null;
          }

     }
}

using AutoMapper;
using FoodMarket.Data;
using FoodMarket.Pages.WishLists.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FoodMarket.Pages.WishLists.Query.GetById
{
     public class GetWishListByIdQueryHandler : IRequestHandler<GetWishListByIdQuery, WishListDto>
     {
          private readonly DataContext _context;
          private readonly IMapper _mapper;

          public GetWishListByIdQueryHandler(DataContext context, IMapper mapper)
          {
               _context = context;
               _mapper = mapper;
          }

          public async Task<WishListDto> Handle(GetWishListByIdQuery request, CancellationToken cancellationToken)
          {
               var wishList = await _context.WishLists
                    .Where(x => x.UserId == request.Id)
                    .Include(x => x.WishListItems)
                    .FirstOrDefaultAsync(cancellationToken);

               if (wishList != null)
               {
                    return _mapper.Map<WishListDto>(wishList);
               }

               return null;
          }
     }
}

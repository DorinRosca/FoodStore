using AutoMapper;
using FoodMarket.Data;
using FoodMarket.Pages.WishLists.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FoodMarket.Pages.WishLists.Query.GetAll
{
     public class GetAllWishListQueryHandler : IRequestHandler<GetAllWishListQuery, IEnumerable<WishListDto>>
     {
          private readonly DataContext _context;
          private readonly IMapper _mapper;

          public GetAllWishListQueryHandler(DataContext context, IMapper mapper)
          {
               _context = context;
               _mapper = mapper;
          }

          public Task<IEnumerable<WishListDto>> Handle(GetAllWishListQuery request, CancellationToken cancellationToken)
          {
               var wishListsWithItems = _context.WishLists
                    .Include(c => c.WishListItems)
                    .AsEnumerable();

               var list = wishListsWithItems.Select(entity => _mapper.Map<WishListDto>(entity));
               return Task.FromResult(list);
          }
     }
}

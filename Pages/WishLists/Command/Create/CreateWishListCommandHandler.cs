using AutoMapper;
using FoodMarket.Data;
using FoodMarket.Pages.WishLists.Entities;
using MediatR;

namespace FoodMarket.Pages.WishLists.Command.Create
{
     public class CreateWishListCommandHandler : IRequestHandler<CreateWishListCommand, bool>
     {
          private readonly DataContext _context;
          private readonly IMapper _mapper;
          public CreateWishListCommandHandler(DataContext context, IMapper mapper)
          {
               _context = context;
               _mapper = mapper;
          }
          public async Task<bool> Handle(CreateWishListCommand request, CancellationToken cancellationToken)
          {
               var list = new WishList
               {
                    UserId = request.User.Id
               };
               await _context.WishLists.AddAsync(list, cancellationToken);
               var result = await _context.SaveChangesAsync(cancellationToken);
               return result > 0;
          }
     }
}

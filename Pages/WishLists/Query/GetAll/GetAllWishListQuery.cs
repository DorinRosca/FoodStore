using FoodMarket.Pages.WishLists.Dto;
using MediatR;

namespace FoodMarket.Pages.WishLists.Query.GetAll
{
     public record GetAllWishListQuery : IRequest<IEnumerable<WishListDto>>
     {
     }
}

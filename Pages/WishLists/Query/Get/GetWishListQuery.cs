using FoodMarket.Pages.WishLists.Dto;
using MediatR;

namespace FoodMarket.Pages.WishLists.Query.Get
{
     public record GetWishListQuery : IRequest<WishListDto?>;
}

using FoodMarket.Pages.WishLists.Dto;
using MediatR;

namespace FoodMarket.Pages.WishLists.Query.GetById
{
     public record GetWishListByIdQuery(string Id) : IRequest<WishListDto>
     {
          public string Id { get; set; } = Id;
     }
}

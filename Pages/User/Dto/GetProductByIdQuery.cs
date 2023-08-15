using FoodMarket.Pages.Products.Dto;
using MediatR;

namespace FoodMarket.Pages.User.Dto
{
    public record GetProductByIdQuery(int Id) : IRequest<ProductDto?>
    {
        public int Id = Id;
    }
}

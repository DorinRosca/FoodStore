using FoodMarket.Pages.Products.Dto;
using MediatR;

namespace FoodMarket.Pages.Products.Query.GetAll
{
     public class GetAllProductsQuery : IRequest<IEnumerable<ProductDto>>
     {
     }
}

using FoodMarket.Pages.Categories.Dto;
using MediatR;

namespace FoodMarket.Pages.Categories.Query.GetAll
{
     public class GetAllCategoryQuery : IRequest<IEnumerable<CategoryDto>>
     {
     }
}

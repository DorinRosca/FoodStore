using FoodMarket.Pages.Categories.Dto;
using MediatR;

namespace FoodMarket.Pages.Categories.Query.GetById
{
     public record GetCategoryByIdQuery(int Id) : IRequest<CategoryDto?>
     {
          public int Id = Id;
     }
}

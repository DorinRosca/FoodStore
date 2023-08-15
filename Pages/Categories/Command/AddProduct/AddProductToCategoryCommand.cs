using FoodMarket.Pages.Categories.Dto;
using MediatR;

namespace FoodMarket.Pages.Categories.Command.AddProduct
{
     public record AddProductToCategoryCommand(ProductCategoryDto Model) : IRequest<bool>
     {
          public int CategoriesId { get; set; } = Model.CategoriesId;
          public int ProductsId { get; set; } = Model.ProductsId;


     }
}

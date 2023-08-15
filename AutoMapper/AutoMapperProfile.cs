using AutoMapper;
using FoodMarket.Pages.Categories.Command.Create;
using FoodMarket.Pages.Categories.Command.Edit;
using FoodMarket.Pages.Categories.Dto;
using FoodMarket.Pages.Categories.Entities;
using FoodMarket.Pages.Products.Command.Create;
using FoodMarket.Pages.Products.Command.Edit;
using FoodMarket.Pages.Products.Dto;
using FoodMarket.Pages.Products.Entities;
using FoodMarket.Pages.User.Command.AddRole;
using FoodMarket.Pages.User.Command.Login;
using FoodMarket.Pages.User.Dto;
using FoodMarket.Pages.WishLists.Command.Create;
using FoodMarket.Pages.WishLists.Dto;
using FoodMarket.Pages.WishLists.Entities;
using Microsoft.AspNetCore.Identity;

namespace FoodMarket.AutoMapper
{
     public class AutoMapperProfile : Profile
     {
          public AutoMapperProfile()
          {
               CreateMap<CreateCategoryCommand, Category>();
               CreateMap<Category, CategoryDto>();
               CreateMap<EditCategoryCommand, Category>();

               CreateMap<CreateProductCommand, Product>();
               CreateMap<Product, ProductDto>();
               CreateMap<EditProductCommand, Product>();

               CreateMap<LoginUserCommand, IdentityUser>();
               CreateMap<AddRoleCommand, IdentityRole>();

               CreateMap<CreateWishListCommand, WishList>();
               CreateMap<WishList, WishListDto>();

               CreateMap<LoginUserCommand, LoginUser>();


          }
     }
}

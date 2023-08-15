using FoodMarket.Pages.WishListItems.Command.AddToWishList;
using FoodMarket.Pages.WishListItems.Command.DeleteFromWishList;
using FoodMarket.Pages.WishListItems.Dto;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FoodMarket.Pages.WishListItems
{
     [Route("api/wishlistitem")]
     [ApiController]
     public class WishListsController : ControllerBase
     {
          private readonly IMediator _mediator;

          public WishListsController(IMediator mediator)
          {
               _mediator = mediator;
          }
          /// <summary>
          /// add a new product in wish list
          /// </summary>
          /// <param name="product"></param>
          /// <returns></returns>
          /// 
          [HttpPost("add")]
          [Authorize]
          public async Task<IActionResult> AddProductToWishList([FromBody] WishListProductDto product)
          {
               var result = await _mediator.Send(new AddToWishListCommand(product));
               if (result)
                    return Ok(result);
               return BadRequest();
          }
          /// <summary>
          /// delete a quantity of product from wishlist
          /// </summary>
          /// <param name="product"></param>
          /// <returns></returns>
          [HttpDelete("delete")]
          [Authorize]
          public async Task<IActionResult> DeleteProductToWishList([FromBody] WishListProductDto product)
          {
               var result = await _mediator.Send(new DeleteFromWishListCommand(product));
               if (result)
                    return Ok(result);
               return BadRequest();
          }
     }
}

using FoodMarket.Pages.WishLists.Query.Get;
using FoodMarket.Pages.WishLists.Query.GetAll;
using FoodMarket.Pages.WishLists.Query.GetById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace FoodMarket.Pages.WishLists
{
     [Route("api/wishlist")]
     [ApiController]
     public class WishListsController : ControllerBase
     {
          private readonly IMediator _mediator;


          public WishListsController(IMediator mediator)
          {
               _mediator = mediator;
          }
          /// <summary>
          /// get user wishList
          /// </summary>
          /// <response code="200">the wish list was successfully displayed </response>
          /// <response code="400">Unable to get wish list or it does not exist</response>
          [HttpGet("get")]
          [Authorize]
          public async Task<IActionResult> Get()
          {
               var products = await _mediator.Send(new GetWishListQuery());
               if (products == null)
               {
                    return NotFound();
               }
               return Ok(products);
          }
          /// <summary>
          /// get all users wish lists
          /// </summary>
          /// <returns></returns>
          ///<response code="200">the wish lists was successfully displayed </response>
          /// <response code="400">Unable to get wish lists or the list is empty</response>
          [HttpGet("get/all")]
          [Authorize(Roles = "Manager")]
          public async Task<IActionResult> GetAllWishLists()
          {
               var result = await _mediator.Send(new GetAllWishListQuery());
               if (result.IsNullOrEmpty())
               {
                    return NotFound();
               }
               return Ok(result);
          }
          /// <summary>
          /// get an specific user wish list
          /// </summary>
          /// <param name="id"></param>
          /// <returns></returns>
          /// <response code="200">the wish list was successfully displayed </response>
          /// <response code="400">Unable to get wish list or it does not exist</response>
          [HttpGet("get/{id}")]
          [Authorize(Roles = "Manager")]
          public async Task<IActionResult> GetWishListById(string id)
          {
               var result = await _mediator.Send(new GetWishListByIdQuery(id));
               if (result == null)
               {
                    return NotFound();
               }
               return Ok(result);
          }
     }
}

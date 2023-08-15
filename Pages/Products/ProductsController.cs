using FoodMarket.Pages.Products.Command.Create;
using FoodMarket.Pages.Products.Command.Delete;
using FoodMarket.Pages.Products.Command.Edit;
using FoodMarket.Pages.Products.Dto;
using FoodMarket.Pages.Products.Query.GetAll;
using FoodMarket.Pages.Products.Query.GetById;
using FoodMarket.Pages.User.Dto;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace FoodMarket.Pages.Products
{
     [Route("api/products")]
     [ApiController]
     public class ProductsController : ControllerBase
     {
          private readonly IMediator _mediator;

          public ProductsController(IMediator mediator)
          {
               _mediator = mediator;
          }


          /// <summary>
          /// add a new product in DBase
          /// </summary>
          /// <param name="product"></param>
          /// <returns></returns>
          /// <response code="200">the product was successfully added in DBase </response>
          /// <response code="400">Unable to add product due to validation error or an product with such name already exist</response>
          [HttpPost("add")]
          [Authorize(Roles = "Manager")]
          public async Task<IActionResult> AddProduct([FromBody] CreateProductDto product)
          {
               var result = await _mediator.Send(new CreateProductCommand(product));
               if (result)
                    return Ok(result);
               return BadRequest();
          }

          //404
          //200
          /// <summary>
          /// delete a existing product from DBase
          /// </summary>
          /// <param name="id"></param>
          /// <returns></returns>
          /// <response code="200">the product was successfully deleted from DBase </response>
          /// <response code="404">specified product was not found or does not exist</response>
          [HttpDelete("delete/{id}")]
          [Authorize(Roles = "Manager")]
          public async Task<IActionResult> DeleteProduct(int id)
          {
               var result = await _mediator.Send(new DeleteProductCommand(id));
               if (result)
                    return Ok(result);
               return NotFound();
          }


          /// <summary>
          /// edit a existing product from DBase
          /// </summary>
          /// <param name="id"></param>
          /// <param name="product"></param>
          /// <returns></returns>
          /// <response code="200">product was successfully edited </response>
          /// <response code="400">Unable to edit product to category due to validation error</response>
          [HttpPut("edit/{id}")]
          [Authorize(Roles = "Manager")]

          public async Task<IActionResult> EditProduct(int id, [FromBody] EditProductDto product)
          {
               var editedProduct = await _mediator.Send(new EditProductCommand(id, product));


               if (editedProduct)
               {
                    return Ok(editedProduct);
               }
               return BadRequest();
          }


          /// <summary>
          /// get all products from DBase
          /// </summary>
          /// <response code="200">all list of products was successfully displayed </response>
          /// <response code="404">there were no products in DBase</response>
          [HttpGet]
          public async Task<IActionResult> GetAll()
          {
               var products = await _mediator.Send(new GetAllProductsQuery());
               if (products.IsNullOrEmpty())
                    return NotFound(products);
               return Ok(products);
          }


          /// <summary>
          /// get a specific product from DBase
          /// </summary>
          /// <param name="id"></param>
          /// <returns></returns>
          /// <response code="200">the product was successfully displayed </response>
          /// <response code="404">there is no product with such id in DBase</response>
          [HttpGet("get/{id}")]
          public async Task<IActionResult> GetProduct(int id)
          {
               var product = await _mediator.Send(new GetProductByIdQuery(id));
               if (product == null)
                    return Ok(product);
               return NotFound(product);
          }

     }
}

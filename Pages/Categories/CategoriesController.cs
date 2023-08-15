using FoodMarket.Pages.Categories.Command.AddProduct;
using FoodMarket.Pages.Categories.Command.Create;
using FoodMarket.Pages.Categories.Command.Delete;
using FoodMarket.Pages.Categories.Command.Edit;
using FoodMarket.Pages.Categories.Dto;
using FoodMarket.Pages.Categories.Query.GetAll;
using FoodMarket.Pages.Categories.Query.GetById;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace FoodMarket.Pages.Categories
{
     [Route("api/categories")]
     [ApiController]
     public class CategoriesController : ControllerBase
     {
          private readonly IMediator _mediator;

          public CategoriesController(IMediator mediator)
          {
               _mediator = mediator;
          }

          /// <summary>
          /// add a product to a specific category 
          /// </summary>
          /// <param name="model"></param>
          /// <returns></returns>
          /// <response code="200">product was successfully assigned to category</response>
          /// <response code="400">Unable to assign product to category due to validation error</response>

          [HttpPost("product/add")]
          [Authorize(Roles = "Manager")]
          public async Task<IActionResult> AddProduct([FromBody] ProductCategoryDto model)
          {
               var result = await _mediator.Send(new AddProductToCategoryCommand(model));
               if (result)
                    return Ok(result);
               return BadRequest();
          }



          /// <summary>
          /// add a new category in DBase
          /// </summary>
          /// <param name="category"></param>
          /// <returns></returns>
          /// <response code="200">category was successfully added in DBase </response>
          /// <response code="400">Unable to create category to category due to validation error</response>
          [HttpPost("add")]
          [Authorize(Roles = "Manager")]
          public async Task<IActionResult> AddCategory([FromBody] CreateCategoryDto category)
          {
               var result = await _mediator.Send(new CreateCategoryCommand(category));
               if (result)
                    return Ok(result);
               return BadRequest();
          }


          /// <summary>
          /// delete a new category from DBase
          /// </summary>
          /// <param name="id"></param>
          /// <returns></returns>
          /// <response code="200">category was successfully deleted from DBase </response>
          /// <response code="404">specified category was not found or does not exist</response>

          [HttpDelete("delete/{id}")]
          [Authorize(Roles = "Manager")]
          public async Task<IActionResult> DeleteCategory(int id)
          {
               var result = await _mediator.Send(new DeleteCategoryCommand(id));
               if (result)
                    return Ok(result);
               return NotFound();
          }
          /// <summary>
          /// edit existing category
          /// </summary>
          /// <param name="id"></param>
          /// <param name="category"></param>
          /// <returns></returns>
          /// <response code="200">category was successfully edited </response>
          /// <response code="400">Unable to edit category to category due to validation error</response>

          [Authorize(Roles = "Manager")]
          [HttpPut("edit/{id}")]
          public async Task<IActionResult> EditCategory(int id, [FromBody] EditCategoryDto category)
          {
               var editedCategory = await _mediator.Send(new EditCategoryCommand(id, category));


               if (editedCategory)
               {
                    return Ok(editedCategory);
               }
               return BadRequest();
          }

          /// <summary>
          /// get all categories from DBase
          /// </summary>
          /// <returns></returns>
          /// <response code="200">all list of categories was successfully displayed </response>
          /// <response code="404">there were no categories in DBase</response>

          [HttpGet]
          public async Task<IActionResult> GetAll()
          {
               var categories = await _mediator.Send(new GetAllCategoryQuery());
               if (categories.IsNullOrEmpty())
                    return NotFound(categories);
               return Ok(categories);
          }


          /// <summary>
          /// get a specific category from DBase
          /// </summary>
          /// <param name="id"></param>
          /// <returns></returns>
          /// <response code="200">the category was successfully displayed </response>
          /// <response code="404">there is no category with such id in DBase</response>
          [HttpGet("get/{id}")]
          public async Task<IActionResult> GetCategory(int id)
          {
               var category = await _mediator.Send(new GetCategoryByIdQuery(id));
               if (category == null)
                    return Ok(category);
               return NotFound(category);
          }

     }
}

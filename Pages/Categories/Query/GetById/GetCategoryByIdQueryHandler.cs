using AutoMapper;
using FoodMarket.Data;
using FoodMarket.Pages.Categories.Dto;
using MediatR;

namespace FoodMarket.Pages.Categories.Query.GetById
{
     public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, CategoryDto?>
     {
          private readonly DataContext _context;
          private readonly IMapper _mapper;

          public GetCategoryByIdQueryHandler(DataContext context, IMapper mapper)
          {
               _context = context;
               _mapper = mapper;
          }

          public async Task<CategoryDto?> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
          {
               if (request.Id == 0)
               {
                    throw new ArgumentNullException(nameof(request.Id), "The Id parameter cannot be zero.");

               }
               var entity = await _context.Categories.FindAsync(request.Id);
               if (entity == null)
               {
                    return null;
               }

               var model = _mapper.Map<CategoryDto>(entity);
               return model;
          }
     }
}

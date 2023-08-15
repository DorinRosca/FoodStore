using AutoMapper;
using FoodMarket.Data;
using FoodMarket.Pages.Categories.Dto;
using LazyCache;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FoodMarket.Pages.Categories.Query.GetAll
{
     public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery, IEnumerable<CategoryDto>>
     {
          private readonly DataContext _context;
          private readonly IMapper _mapper;
          private readonly IAppCache _appCache;

          public GetAllCategoryQueryHandler(DataContext context, IMapper mapper, IAppCache cache)
          {
               _context = context;
               _mapper = mapper;
               _appCache = cache;
          }

          public async Task<IEnumerable<CategoryDto>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
          {
               var dataList =
                    await _appCache.GetOrAddAsync("AllCategories.Get", () => _context.Categories
                              .Include(c => c.Products).ToListAsync(cancellationToken)
                         , DateTime.Now.AddHours(4));
               var result = dataList.Select(entity => _mapper.Map<CategoryDto>(entity));

               return result;
          }
     }
}

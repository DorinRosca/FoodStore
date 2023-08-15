using AutoMapper;
using FoodMarket.Data;
using FoodMarket.Pages.Products.Dto;
using LazyCache;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FoodMarket.Pages.Products.Query.GetAll
{
     public class GetAllProductsQueryHandler : IRequestHandler<GetAllProductsQuery, IEnumerable<ProductDto>>
     {
          private readonly DataContext _context;
          private readonly IMapper _mapper;
          private readonly IAppCache _appCache;

          public GetAllProductsQueryHandler(DataContext context, IMapper mapper, IAppCache cache)
          {
               _context = context;
               _mapper = mapper;
               _appCache = cache;
          }

          public async Task<IEnumerable<ProductDto>> Handle(GetAllProductsQuery request, CancellationToken cancellationToken)
          {
               var dataList =
                    await _appCache.GetOrAddAsync("AllProducts.Get", () => _context.Products
                         .Include(c => c.Categories)
                         .ToListAsync(cancellationToken), DateTime.Now.AddHours(4));
               var result = dataList.Select(entity => _mapper.Map<ProductDto>(entity));
               return result;
          }
     }
}

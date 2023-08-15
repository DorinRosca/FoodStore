using AutoMapper;
using FoodMarket.Data;
using FoodMarket.Pages.Products.Dto;
using FoodMarket.Pages.User.Dto;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FoodMarket.Pages.Products.Query.GetById
{
    public class GetProductByIdQueryHandler : IRequestHandler<GetProductByIdQuery, ProductDto?>
     {
          private readonly DataContext _context;
          private readonly IMapper _mapper;

          public GetProductByIdQueryHandler(DataContext context, IMapper mapper)
          {
               _context = context;
               _mapper = mapper;
          }

          public async Task<ProductDto?> Handle(GetProductByIdQuery request, CancellationToken cancellationToken)
          {
               if (request.Id == 0)
               {
                    throw new ArgumentNullException(nameof(request.Id), "The Id parameter cannot be zero.");

               }

               var entity = await _context.Products.Include(c => c.Categories)
                    .FirstOrDefaultAsync(c => c.ProductId == request.Id, cancellationToken);
               if (entity == null)
               {
                    throw new ArgumentNullException(nameof(request.Id), "There is no entity with such Id.");

               }

               var model = _mapper.Map<ProductDto>(entity);
               return model;
          }
     }
}

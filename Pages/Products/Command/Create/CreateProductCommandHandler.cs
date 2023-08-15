using AutoMapper;
using FoodMarket.Data;
using FoodMarket.Pages.Products.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace FoodMarket.Pages.Products.Command.Create
{
     public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, bool>
     {
          private readonly DataContext _context;
          private readonly IMapper _mapper;
          private readonly IMediator _mediator;
          public CreateProductCommandHandler(DataContext context, IMapper mapper, IMediator mediator)
          {
               _context = context;
               _mapper = mapper;
               _mediator = mediator;
          }
          public async Task<bool> Handle(CreateProductCommand? request, CancellationToken cancellationToken)
          {
               if (request == null)
               {
                    return false;
               }

               if (!await ProductExists(request))
               {
                    return false;
               }
               var product = _mapper.Map<Product>(request);
               await _context.Products.AddAsync(product, cancellationToken);
               var result = await _context.SaveChangesAsync(cancellationToken);
               return result > 0;
          }

          public async Task<bool> ProductExists(CreateProductCommand request)
          {
               var result = await _context.Products.FirstOrDefaultAsync(c => c.Name == request.Name);
               if (result == null)
               {
                    return true;
               }
               return false;
          }
     }
}

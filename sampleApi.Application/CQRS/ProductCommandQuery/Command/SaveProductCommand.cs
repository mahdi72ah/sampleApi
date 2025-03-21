using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using sampleApi.Application.Interfaces;
using sampleApi.Infrastructure.Dtos;

namespace sampleApi.Application.CQRS.ProductCommandQuery.Command
{ 
    public class SaveProductCommand:IRequest<SaveProductCommandResponse>
    {
        public ProductDto ProductDto { get; set; }
    }

    public class SaveProductCommandResponse
    {
        public int ProductId { get; set; }
    }

    public class SaveProductCommandHandler : IRequestHandler<SaveProductCommand, SaveProductCommandResponse>
    {
        private readonly IProductService _productService;

        public SaveProductCommandHandler(IProductService productService)
        {
            _productService = productService;
        }
        public async Task<SaveProductCommandResponse> Handle(SaveProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productService.Add(request.ProductDto);
            var result = new SaveProductCommandResponse
            {
                ProductId = product.Id
            };
            return result;
        }
    }
}

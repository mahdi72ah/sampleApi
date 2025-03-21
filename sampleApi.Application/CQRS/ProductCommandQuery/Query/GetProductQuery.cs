using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using sampleApi.Core.IReposirories;



namespace sampleApi.Application.CQRS.ProductCommandQuery.Query
{
    public class GetProductQuery:IRequest<GetProductQueryResponse>
    {
        public int Id{ get; set; }
    }

    public class GetProductQueryResponse
    {
        public int Id { get; set; }
        public string? ProductName { get; set; }
        public string? PriceWithComma { get; set; }
        public long Price { get; set; }
        // اضافه کردن فیلد جدید برای ترکیب Name و Price
        public string CombinedInfo => $"{ProductName} {Price}";
    }

    public class ProductQueryHandler : IRequestHandler<GetProductQuery, GetProductQueryResponse>
    {
        private readonly IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductQueryHandler(IProductRepository repository,IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<GetProductQueryResponse> Handle(GetProductQuery request, CancellationToken cancellationToken)
        {
            var product = await _repository.GetAsync(request.Id);
            var response = _mapper.Map<GetProductQueryResponse>(product);
            return response;
        }
    }
}

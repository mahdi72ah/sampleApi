using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using sampleApi.Infrastructure.Dtos;

namespace sampleApi.Application.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetAll();
        Task<ProductDto> GetById(int id);
        Task<ProductDto> Add(ProductDto product);
    }
}

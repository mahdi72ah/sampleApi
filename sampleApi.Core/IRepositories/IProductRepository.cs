using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using sampleApi.Core.Entities;

namespace sampleApi.Core.IReposirories
{
    public interface IProductRepository
    {
        Task<Product> GetAsync(int id);
        Task<List<Product>> GetAllAsync();
        Task<int> InsertAsync(Product product);
    }
}

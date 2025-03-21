using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using sampleApi.Core;
using sampleApi.Core.Entities;
using sampleApi.Core.IReposirories;

namespace sampleApi.Infrastructure.Reposirories
{
    public class ProductRepository:IProductRepository
    {
        private readonly SampleApiDbContext _dbContext;

        public ProductRepository(SampleApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Product>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Product> GetAsync(int id)
        {
            return await _dbContext.Product.FindAsync(id);
        }

        public async Task<int> InsertAsync(Product product)
        {
            await _dbContext.AddAsync(product);
            return product.Id;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using sampleApi.Core;
using sampleApi.Infrastructure.UnitOfWorks;

namespace sampleApi.Infrastructure
{
    public class UnitOfWork:IUnitOfWork
    {
        private readonly SampleApiDbContext _dbContext;

        public UnitOfWork(SampleApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<int> SaveChangeAsync()
        {
           return await _dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}

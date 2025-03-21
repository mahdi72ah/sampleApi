using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace sampleApi.Infrastructure.UnitOfWorks
{
    public interface IUnitOfWork:IDisposable
    {
        Task<int> SaveChangeAsync();
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using sampleApi.Core.Entities;

namespace sampleApi.Core.IRepositories
{
    public interface IUsersRepository
    {
        Task<Users> GetAsyncById(int Id);
        Task<Users> GetAsyncByUserName(string UserName);
        Task<List<Users>> GetAllAsync();
        Task<Guid> InsertAsync(Users users);
    }
}

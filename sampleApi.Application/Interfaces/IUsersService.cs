using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using sampleApi.Core.Entities;

namespace sampleApi.Application.Interfaces
{
    public interface IUsersService
    {
        Task<Users> GetAsyncById(int Id);
        Task<Users> GetAsyncByUserName(string passWord,string UserName);
        Task<List<Users>> GetAllAsync();
        Task<Guid> InsertAsync(Users UserName);
    }
}

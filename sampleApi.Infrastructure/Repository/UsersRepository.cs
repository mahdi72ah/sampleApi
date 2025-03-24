using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using sampleApi.Core;
using sampleApi.Core.Entities;
using sampleApi.Core.IRepositories;

namespace sampleApi.Infrastructure.Repository
{
    public class UsersRepository:IUsersRepository
    {
        private readonly SampleApiDbContext _dbContext;

        public UsersRepository(SampleApiDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public Task<Users> GetAsyncById(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<Users> GetAsyncByUserName(string UserName)
        {
            return await _dbContext.Users.SingleOrDefaultAsync(s => s.UserName == UserName);
        }

        public Task<List<Users>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Guid> InsertAsync(Users users)
        {
            await _dbContext.AddAsync(users);
            return users.Id;
        }
    }
}

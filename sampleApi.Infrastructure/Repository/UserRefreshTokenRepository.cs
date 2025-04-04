using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using sampleApi.Core;
using sampleApi.Core.Entities;
using sampleApi.Core.IRepositories;
using sampleApi.Infrastructure.Model;

namespace sampleApi.Infrastructure.Repository
{
    public class UserRefreshTokenRepository: IUserRefreshTokenRepository
    {
        private readonly SampleApiDbContext _sampleApiDbContext;
     

        public UserRefreshTokenRepository(SampleApiDbContext sampleApiDbContext)
        {
            _sampleApiDbContext = sampleApiDbContext;
        }
        public async Task<int> AddRefreshToken(UserRefreshToken userRefreshToken)
        {
            await _sampleApiDbContext.UserRefreshToken.AddAsync(userRefreshToken);
            return userRefreshToken.Id;
        }

        public async Task<UserRefreshToken> GetUserRefreshTokenWithRefreshRoken(UserRefreshToken userRefreshToken)
        {
            var result =
                await _sampleApiDbContext.UserRefreshToken.SingleOrDefaultAsync(p =>
                    p.UsersId==userRefreshToken.UsersId);
            return result;
        }

        public async Task<UserRefreshToken> UpdateUserRefreshToken(UserRefreshToken userRefreshToken,UserRefreshToken UpdateUserRefreshToken)
        {
            userRefreshToken.RefreshToken= UpdateUserRefreshToken.RefreshToken;
            userRefreshToken.IsValid=true;
            userRefreshToken.RefreshTokenTimeOut = UpdateUserRefreshToken.RefreshTokenTimeOut;
            userRefreshToken.CreateDate = UpdateUserRefreshToken.CreateDate;
            return userRefreshToken;
        }
    }
}

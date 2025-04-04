using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sampleApi.Core.Entities;

namespace sampleApi.Core.IRepositories
{
    public interface IUserRefreshTokenRepository
    {
        Task<int> AddRefreshToken(UserRefreshToken userRefreshToken);
        Task<UserRefreshToken> GetUserRefreshTokenWithRefreshRoken(UserRefreshToken userRefreshToken);
        Task<UserRefreshToken> UpdateUserRefreshToken(UserRefreshToken userRefreshToken, UserRefreshToken UpdateUserRefreshToken);
    }
}

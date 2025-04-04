using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sampleApi.Core.Entities;

namespace sampleApi.Application.Interfaces
{
    public interface IUserRefreshTokenService
    {
        Task<UserRefreshToken> AddRefreshTokenNotificationAsync(UserRefreshToken userRefreshToken);
    }
}

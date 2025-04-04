using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using sampleApi.Application.Interfaces;
using sampleApi.Core.Entities;
using sampleApi.Core.IRepositories;
using sampleApi.Infrastructure.UnitOfWorks;

namespace sampleApi.Application.Services
{
    public class UserRefreshTokenService: IUserRefreshTokenService
    {
        private readonly IUserRefreshTokenRepository _refreshTokenRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UserRefreshTokenService(IUserRefreshTokenRepository refreshTokenRepository,IUnitOfWork unitOfWork)
        {
            _refreshTokenRepository = refreshTokenRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task<UserRefreshToken> AddRefreshTokenNotificationAsync(UserRefreshToken userRefreshToken)
        {
            var result = await _refreshTokenRepository.GetUserRefreshTokenWithRefreshRoken(userRefreshToken);
            if (result == null)
            {
                await _refreshTokenRepository.AddRefreshToken(userRefreshToken);
            }
            else
            {
                await _refreshTokenRepository.UpdateUserRefreshToken(result, userRefreshToken);
            }

            await _unitOfWork.SaveChangeAsync();
            return result;
        }
    }
}

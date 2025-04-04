using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using sampleApi.Application.Interfaces;
using sampleApi.Core.Entities;
using sampleApi.Core.IRepositories;

namespace sampleApi.Application.CQRS.Notifications
{
    public class AddRefreshTokenNotification : INotification
    {
        public string RefreshToken { get; set; }
        public int RefreshTokenTimeOut { get; set; }
        public Guid UserId { get; set; }
    }

    public class AddRefreshTokenNotificationHandler : INotificationHandler<AddRefreshTokenNotification>
    {
        private readonly IMapper _mapper;
        private readonly IUserRefreshTokenService _userRefreshTokenService;


        public AddRefreshTokenNotificationHandler(IMapper mapper,IUserRefreshTokenService userRefreshTokenService)
        {
            _mapper = mapper;
            _userRefreshTokenService = userRefreshTokenService;
        }
        public async Task Handle(AddRefreshTokenNotification notification, CancellationToken cancellationToken)
        {
            var userRefreshToken = _mapper.Map<UserRefreshToken>(notification);
            var result = await _userRefreshTokenService.AddRefreshTokenNotificationAsync(userRefreshToken);
        }
    }
}

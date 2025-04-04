using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.Options;
using sampleApi.Application.CQRS.Notifications;
using sampleApi.Application.Interfaces;
using sampleApi.Infrastructure.Model;
using sampleApi.Infrastructure.UnitOfWorks;
using sampleApi.Infrastructure.Utilitys;

namespace sampleApi.Application.CQRS.LoginCommandQuery.Command
{
    public class LoginCommand : IRequest<LoginCommandResponse>
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class LoginCommandResponse
    {
        public string UserName { get; set; }
        public string Token { get; set; }
        public string RefreshToken { get; set; }
        public int ExpireTime { get; set; }
    }

    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginCommandResponse>
    {
        private readonly IUsersService _usersService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly EncryptionUtility _encryptionUtility;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;
        private readonly Configs _configs;

        public LoginCommandHandler(IUsersService usersService,IUnitOfWork unitOfWork, EncryptionUtility encryptionUtility,IMapper mapper,IMediator mediator, IOptions<Configs> options)
        {
            _usersService = usersService;
            _unitOfWork = unitOfWork;
            _encryptionUtility = encryptionUtility;
            _mapper = mapper;
            _mediator = mediator;
            _configs = options.Value;
        }
        public async Task<LoginCommandResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user =await _usersService.GetAsyncByUserName(request.Password,request.UserName);
            var token = _encryptionUtility.GetNewToken(user.Id);
            var refreshToken = _encryptionUtility.GetNewRefreshToken();

            //Add To UserRefreshToken
            var addRefreshTokenNotification = new AddRefreshTokenNotification
            {
                RefreshToken = refreshToken,
                UserId = user.Id,
                RefreshTokenTimeOut = _configs.RefreshTokenTimeOut
            };
            await _mediator.Publish(addRefreshTokenNotification);


            var response = new LoginCommandResponse
            {
                ExpireTime = 0,
                Token = token,
                RefreshToken = refreshToken,
                UserName = request.UserName
            };
            return response;
        }
    }
}

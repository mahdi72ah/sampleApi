using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using sampleApi.Application.Interfaces;
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
        public int ExpireTime { get; set; }
    }

    public class LoginCommandHandler : IRequestHandler<LoginCommand, LoginCommandResponse>
    {
        private readonly IUsersService _usersService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly EncryptionUtility _encryptionUtility;

        public LoginCommandHandler(IUsersService usersService,IUnitOfWork unitOfWork, EncryptionUtility encryptionUtility)
        {
            _usersService = usersService;
            _unitOfWork = unitOfWork;
            _encryptionUtility = encryptionUtility;
        }
        public async Task<LoginCommandResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user =await _usersService.GetAsyncByUserName(request.Password,request.UserName);
            var token = _encryptionUtility.GetNewToken(user.Id);
            var response = new LoginCommandResponse
            {
                ExpireTime = 0,
                Token = token,
                UserName = request.UserName
            };
            return response;
        }
    }
}

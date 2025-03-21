using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

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
        public Task<LoginCommandResponse> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}

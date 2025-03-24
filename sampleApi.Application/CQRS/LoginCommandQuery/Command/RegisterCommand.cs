using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using sampleApi.Application.Interfaces;
using sampleApi.Core.Entities;
using sampleApi.Infrastructure.UnitOfWorks;
using sampleApi.Infrastructure.Utilitys;

namespace sampleApi.Application.CQRS.LoginCommandQuery.Command
{
    public class RegisterCommand : IRequest
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }

    public class RegisterCommandHandler : IRequestHandler<RegisterCommand>
    {
        private readonly IUsersService _usersService;
        private readonly IUnitOfWork _unitOfWork;
        private readonly EncryptionUtility _encryptionUtility;

        public RegisterCommandHandler(IUsersService usersService, IUnitOfWork unitOfWork, EncryptionUtility encryptionUtility)
        {
            _usersService = usersService;
            _unitOfWork = unitOfWork;
            _encryptionUtility = encryptionUtility;
        }
        public async Task<Unit> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            var salt = _encryptionUtility.GetNewSalt();
            var HashPassword = _encryptionUtility.GetSHA256(request.Password, salt);
            var user = new Users
            {
                Id = Guid.NewGuid(),
                RegisterDate = DateTime.Now,
                Passsword = HashPassword,
                UserName = request.UserName,
                PasswordSolt = salt
            };
            await _usersService.InsertAsync(user);
            return Unit.Value;
        }
    }
}

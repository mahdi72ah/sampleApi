using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using sampleApi.Application.Interfaces;
using sampleApi.Core.Entities;
using sampleApi.Core.IRepositories;
using sampleApi.Infrastructure.UnitOfWorks;
using sampleApi.Infrastructure.Utilitys;

namespace sampleApi.Application.Services
{
    public class UsersService:IUsersService
    {
        private readonly IUsersRepository _usersRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly EncryptionUtility _encryptionUtility;

        public UsersService(IUsersRepository usersRepository,IMapper mapper,IUnitOfWork unitOfWork,EncryptionUtility encryptionUtility)
        {
            _usersRepository = usersRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
            _encryptionUtility = encryptionUtility;
        }
        public Task<Users> GetAsyncById(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<Users> GetAsyncByUserName(string passWord,string UserName)
        {
            var user = await _usersRepository.GetAsyncByUserName(UserName);
            if (user == null) throw new Exception();

            var hashPassword = _encryptionUtility.GetSHA256(passWord, user.PasswordSolt);
            if(user.Passsword!=hashPassword) throw new Exception();

            return user;

        }

        public Task<List<Users>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Guid> InsertAsync(Users users)
        {
            await _usersRepository.InsertAsync(users);
            await _unitOfWork.SaveChangeAsync();
            return users.Id;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using sampleApi.Core.IReposirories;
using sampleApi.Core.IRepositories;
using sampleApi.Infrastructure.Model;
using sampleApi.Infrastructure.Reposirories;
using sampleApi.Infrastructure.Repository;
using sampleApi.Infrastructure.UnitOfWorks;
using sampleApi.Infrastructure.Utilitys;

namespace sampleApi.Infrastructure
{
    public static class DiRegister
    {
        public static void AddRepositories(this IServiceCollection service)
        {
            service.AddScoped<IProductRepository, ProductRepository>();
            service.AddScoped<IUsersRepository, UsersRepository>();
            service.AddScoped<IUserRefreshTokenRepository, UserRefreshTokenRepository>();
        }

        public static void AddUnitOfWork(this IServiceCollection service)
        {
            service.AddScoped<IUnitOfWork, UnitOfWork>();
        }
        public static void AddEncryptionUtility(this IServiceCollection service)
        {
            service.AddSingleton<EncryptionUtility>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using sampleApi.Core.IReposirories;
using sampleApi.Infrastructure.Reposirories;
using sampleApi.Infrastructure.UnitOfWorks;

namespace sampleApi.Infrastructure
{
    public static class DiRegister
    {
        public static void AddRepositories(this IServiceCollection service)
        {
            service.AddScoped<IProductRepository, ProductRepository>();
        }

        public static void AddUnitOfWork(this IServiceCollection service)
        {
            service.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}

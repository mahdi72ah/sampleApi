using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using AutoMapper;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace sampleApi.Application
{
    public static class ApplicationServicesRegistration
    {
        public static void ConfigureApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
        }
    }
}

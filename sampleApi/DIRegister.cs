using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using sampleApi.Infrastructure.Model;

namespace sampleApi
{
    public static class DIRegister
    {
        public static IServiceCollection AddJwt(this IServiceCollection services)
        {
            var sp = services.BuildServiceProvider();
            Configs configs = sp.GetService<IOptions<Configs>>().Value;
            var key = Encoding.UTF8.GetBytes(configs.TokenKey);

            services.AddAuthentication(options =>
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(key),
                        ClockSkew = TimeSpan.FromMinutes(configs.TokenTimeOut) // برای کاهش زمان تاخیر اعتبار سنجی
                    };
                });

            return services;
        }
    }
}

using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using sampleApi.Infrastructure.Model;

namespace sampleApi.Infrastructure.Utilitys
{
    public class EncryptionUtility
    {
        private readonly Configs _configs;

        public EncryptionUtility(IOptions<Configs> configs)
        {
            _configs = configs.Value;
        }
        public string GetSHA256(string password, string salt)
        {
            using (var sha256=SHA256.Create())
            {
                var bytes=sha256.ComputeHash(Encoding.UTF8.GetBytes(password+salt));
                var hash = BitConverter.ToString(bytes).Replace("-", "").ToLower();
                return hash;
            }
        }

        public string GetNewSalt()
        {
            return Guid.NewGuid().ToString();
        }

        public string GetNewRefreshToken()
        {
            return Guid.NewGuid().ToString();
        }

        public string GetNewToken(Guid userId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.UTF8.GetBytes(_configs.TokenKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim("userId", userId.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes(_configs.TokenTimeOut),
                //Audience = _configs.TokenAudience, // مقدار Audience از تنظیمات خوانده شود
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}

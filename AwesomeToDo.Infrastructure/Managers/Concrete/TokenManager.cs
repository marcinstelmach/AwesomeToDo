using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using AwesomeToDo.Core.Settings;
using AwesomeToDo.Domain.Extensions;
using AwesomeToDo.Infrastructure.Dto.Token;
using AwesomeToDo.Infrastructure.Managers.Abstract;
using Microsoft.IdentityModel.Tokens;

namespace AwesomeToDo.Infrastructure.Managers.Concrete
{
    public class TokenManager : ITokenManager
    {
        private readonly JwtSettings jwtSettings;

        public TokenManager(JwtSettings jwtSettings)
        {
            this.jwtSettings = jwtSettings;
        }

        public TokenDto GenerateToken(Guid userId, string email)
        {
            var now = DateTime.Now;
            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, userId.ToString()),
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Iat, now.ToTimeStamp().ToString(), ClaimValueTypes.Integer64)
            };

            var signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key)), SecurityAlgorithms.HmacSha256);
            var expires = now.AddMinutes(jwtSettings.ExpiryTime);

            var jwt = new JwtSecurityToken(
                issuer: jwtSettings.Issuer,
                claims: claims,
                notBefore: now,
                expires: expires,
                signingCredentials: signingCredentials);

            var token = new JwtSecurityTokenHandler().WriteToken(jwt);
            var tokenDto = new TokenDto(token, expires, userId, email);
            return tokenDto;
        }
    }
}

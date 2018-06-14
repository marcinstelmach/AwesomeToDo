using System;
using System.Collections.Generic;
using System.Text;

namespace AwesomeToDo.Infrastructure.Dto.Token
{
    public class TokenDto
    {
        public TokenDto(string token, DateTime expiry, Guid userId, string email)
        {
            Token = token;
            Expiry = expiry;
            UserId = userId;
            Email = email;
        }

        public string Token { get; protected set; }
        public DateTime Expiry { get; protected set; }
        public Guid UserId { get; protected set; }
        public string Email { get; protected set; }
    }
}

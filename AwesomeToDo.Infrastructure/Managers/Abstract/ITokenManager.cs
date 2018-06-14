using System;
using System.Collections.Generic;
using System.Text;
using AwesomeToDo.Infrastructure.Dto.Token;

namespace AwesomeToDo.Infrastructure.Managers.Abstract
{
    public interface ITokenManager
    {
        TokenDto GenerateToken(Guid userId, string email);
    }
}

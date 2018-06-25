using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AwesomeToDo.Infrastructure.Dto.Card;

namespace AwesomeToDo.Infrastructure.Services.Abstract.Queries
{
    public interface ICardQueryService
    {
        Task<IList<CardDto>> Get(Guid userId);
        Task<CardDto> Get(Guid userId, Guid cardId);
    }
}

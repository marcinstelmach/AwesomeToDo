using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using AwesomeToDo.Core.Exceptions;
using AwesomeToDo.Domain.Extensions;
using AwesomeToDo.Domain.Repositories.Abstract;
using AwesomeToDo.Infrastructure.Dto.ToDo;
using AwesomeToDo.Infrastructure.Services.Abstract.Queries;

namespace AwesomeToDo.Infrastructure.Services.Concrete.Queries
{
    internal class ToDoQueryService : IToDoQueryService
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public ToDoQueryService(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public async Task<IList<ToDoDto>> Get(Guid userId, Guid cardId)
        {
            var user = await userRepository.GetAsync(userId);
            var card = user.Cards.FindIfExist(c => c.Id == cardId, ErrorCode.UserCardNotExist);
            return mapper.Map<IList<ToDoDto>>(card.ToDos);
        }

        public async Task<ToDoDto> Get(Guid userId, Guid cardId, Guid toDoId)
        {
            var user = await userRepository.GetAsync(userId);
            var card = user.Cards.FindIfExist(c => c.Id == cardId, ErrorCode.UserCardNotExist);
            return mapper.Map<ToDoDto>(card.ToDos.FindIfExist(s => s.Id == toDoId, ErrorCode.ToDoNotExist));
        }
    }
}

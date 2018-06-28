using System;
using System.Threading.Tasks;
using AwesomeToDo.Core.Exceptions;
using AwesomeToDo.Domain.Entities;
using AwesomeToDo.Domain.Extensions;
using AwesomeToDo.Domain.Repositories.Abstract;
using AwesomeToDo.Infrastructure.Services.Abstract.Commands;

namespace AwesomeToDo.Infrastructure.Services.Concrete.Commands
{
    internal class ToDoCommandService : IToDoCommandService
    {
        private readonly IUserRepository userRepository;
        private readonly IToDoRepository toDoRepository;

        public ToDoCommandService(IUserRepository userRepository, IToDoRepository doRepository)
        {
            this.userRepository = userRepository;
            toDoRepository = doRepository;
        }

        public async Task AddAsync(Guid userId, Guid cardId, string title)
        {
            var user = await userRepository.GetAsync(userId);
            var card = user.Cards.FindIfExist(s => s.Id == cardId, ErrorCode.UserCardNotExist);
            card.AddToDo(new ToDo(title));
            await userRepository.SaveChangesAsync();
        }

        public async Task UpdateAsync(Guid userId, Guid cardId, Guid toDoId, string title)
        {
            var user = await userRepository.GetAsync(userId);
            var card = user.Cards.FindIfExist(s => s.Id == cardId, ErrorCode.UserCardNotExist);
            var toDo = card.ToDos.FindIfExist(s => s.Id == toDoId, ErrorCode.ToDoNotExist);
            toDo.SetTitle(title);
            await userRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid userId, Guid cardId, Guid toDoId)
        {
            var user = await userRepository.GetAsync(userId);
            var card = user.Cards.FindIfExist(s => s.Id == cardId, ErrorCode.UserCardNotExist);
            var toDo = card.ToDos.FindIfExist(s => s.Id == toDoId, ErrorCode.ToDoNotExist);
            await toDoRepository.DeleteAsync(toDo);
            await toDoRepository.SaveChangesAsync();
        }
    }
}

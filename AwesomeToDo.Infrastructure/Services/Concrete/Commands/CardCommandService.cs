using System;
using System.Threading.Tasks;
using AwesomeToDo.Core.Exceptions;
using AwesomeToDo.Domain.Entities;
using AwesomeToDo.Domain.Extensions;
using AwesomeToDo.Domain.Repositories.Abstract;
using AwesomeToDo.Infrastructure.Services.Abstract.Commands;

namespace AwesomeToDo.Infrastructure.Services.Concrete.Commands
{
    internal class CardCommandService : ICardCommandService
    {
        private readonly IUserRepository userRepository;
        private readonly ICardRepository cardRepository;

        public CardCommandService(IUserRepository userRepository, ICardRepository cardRepository)
        {
            this.userRepository = userRepository;
            this.cardRepository = cardRepository;
        }

        public async Task AddAsync(Guid userId, string title)
        {
            var user = await userRepository.GetAsync(userId);
            var card = new Card(title);
            user.AddCard(card);
            await userRepository.SaveChangesAsync();
        }

        public async Task UpdateAsync(Guid cardId, Guid userId, string title)
        {
            var user = await userRepository.GetAsync(userId);
            var card = user.Cards.FindIfExist(s => s.Id == cardId, ErrorCode.NotFoundUserCard);
            card.SetTitle(title);
            await cardRepository.UpdateAsync(card);
            await cardRepository.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id, Guid userId)
        {
            var user = await userRepository.GetAsync(userId);
            var card = user.Cards.FindIfExist(s => s.Id == id, ErrorCode.NotFoundUserCard);
            await cardRepository.DeleteAsync(card);
            await cardRepository.SaveChangesAsync();
        }
    }
}

using System;
using System.Threading.Tasks;
using AwesomeToDo.Infrastructure.Commands.Abstract;
using AwesomeToDo.Infrastructure.Commands.Models.Card;
using AwesomeToDo.Infrastructure.Services.Abstract.Commands;

namespace AwesomeToDo.Infrastructure.Commands.Handlers.Cards
{
    public class UpdateCardCommandHandler : ICommandHandler<UpdateCardCommandModel>
    {
        private readonly ICardCommandService cardCommandService;

        public UpdateCardCommandHandler(ICardCommandService cardCommandService)
        {
            this.cardCommandService = cardCommandService;
        }

        public async Task HandleAsync(UpdateCardCommandModel command)
            => await cardCommandService.UpdateAsync(command.Id, command.UserId, command.Title);
    }
}

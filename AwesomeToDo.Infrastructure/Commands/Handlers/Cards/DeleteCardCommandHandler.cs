using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using AwesomeToDo.Infrastructure.Commands.Abstract;
using AwesomeToDo.Infrastructure.Commands.Models.Card;
using AwesomeToDo.Infrastructure.Services.Abstract.Commands;

namespace AwesomeToDo.Infrastructure.Commands.Handlers.Cards
{
    public class DeleteCardCommandHandler : ICommandHandler<DeleteCardCommandModel>
    {
        private readonly ICardCommandService cardCommandService;

        public DeleteCardCommandHandler(ICardCommandService cardCommandService)
        {
            this.cardCommandService = cardCommandService;
        }

        public async Task HandleAsync(DeleteCardCommandModel command)
            => await cardCommandService.DeleteAsync(command.Id, command.UserId);
    }
}

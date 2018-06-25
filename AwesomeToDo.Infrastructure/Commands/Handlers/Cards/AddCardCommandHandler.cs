using System.Threading.Tasks;
using AwesomeToDo.Infrastructure.Commands.Abstract;
using AwesomeToDo.Infrastructure.Commands.Models.Card;
using AwesomeToDo.Infrastructure.Services.Abstract.Commands;

namespace AwesomeToDo.Infrastructure.Commands.Handlers.Cards
{
    public class AddCardCommandHandler : ICommandHandler<AddCardCommandModel>
    {
        private readonly ICardCommandService cardCommandService;

        public AddCardCommandHandler(ICardCommandService cardCommandService)
        {
            this.cardCommandService = cardCommandService;
        }

        public async Task HandleAsync(AddCardCommandModel command)
            => await cardCommandService.AddAsync(command.UserId, command.Title);
    }
}

using System.Threading;
using System.Threading.Tasks;
using AwesomeToDo.Infrastructure.Requests.Models.Cards;
using AwesomeToDo.Infrastructure.Services.Abstract.Commands;
using MediatR;

namespace AwesomeToDo.Infrastructure.Requests.Handlers.Cards
{
    public class AddCardRequestHandler : IRequestHandler<AddCardRequestModel, Unit>
    {
        private readonly ICardCommandService cardCommandService;

        public AddCardRequestHandler(ICardCommandService cardCommandService)
        {
            this.cardCommandService = cardCommandService;
        }

        public async Task<Unit> Handle(AddCardRequestModel request, CancellationToken cancellationToken)
        {
            await cardCommandService.AddAsync(request.UserId, request.Title);
            return Unit.Value;
        }
    }
}

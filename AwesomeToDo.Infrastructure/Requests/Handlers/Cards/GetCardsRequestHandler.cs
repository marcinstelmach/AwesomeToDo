using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AwesomeToDo.Infrastructure.Dto.Card;
using AwesomeToDo.Infrastructure.Requests.Models.Cards;
using AwesomeToDo.Infrastructure.Services.Abstract.Queries;
using MediatR;

namespace AwesomeToDo.Infrastructure.Requests.Handlers.Cards
{
    public class GetCardsRequestHandler : IRequestHandler<GetCardsRequestModel, IEnumerable<CardDto>>
    {
        private readonly ICardQueryService cardQueryService;

        public GetCardsRequestHandler(ICardQueryService cardQueryService)
        {
            this.cardQueryService = cardQueryService;
        }

        public async Task<IEnumerable<CardDto>> Handle(GetCardsRequestModel request,
            CancellationToken cancellationToken)
            => await cardQueryService.Get(request.Id);
    }
}

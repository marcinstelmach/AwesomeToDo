using System;
using System.Collections.Generic;
using AwesomeToDo.Infrastructure.Dto.Card;
using MediatR;

namespace AwesomeToDo.Infrastructure.Requests.Models.Cards
{
    public class GetCardsRequestModel : IRequest<IEnumerable<CardDto>>
    {
        public Guid Id { get; }

        public GetCardsRequestModel(Guid id)
        {
            Id = id;
        }
    }
}

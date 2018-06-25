using System;
using AwesomeToDo.Infrastructure.Commands.Abstract;

namespace AwesomeToDo.Infrastructure.Commands.Models.Card
{
    public class DeleteCardCommandModel : ICommandModel
    {
        public DeleteCardCommandModel(Guid id, Guid userId)
        {
            Id = id;
            UserId = userId;
        }

        public Guid Id { get; }
        public Guid UserId { get; }
    }
}

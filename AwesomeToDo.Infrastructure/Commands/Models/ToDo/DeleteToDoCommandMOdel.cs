using System;
using AwesomeToDo.Infrastructure.Commands.Abstract;

namespace AwesomeToDo.Infrastructure.Commands.Models.ToDo
{
    public class DeleteToDoCommandModel : ICommandModel
    {
        public Guid Id { get; }
        public Guid CardId { get; }
        public Guid UserId { get; }

        public DeleteToDoCommandModel(Guid id, Guid cardId, Guid userId)
        {
            Id = id;
            CardId = cardId;
            UserId = userId;
        }
    }
}

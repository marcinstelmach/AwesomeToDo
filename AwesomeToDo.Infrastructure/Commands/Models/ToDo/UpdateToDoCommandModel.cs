using System;
using System.ComponentModel.DataAnnotations;
using AwesomeToDo.Infrastructure.Commands.Abstract;

namespace AwesomeToDo.Infrastructure.Commands.Models.ToDo
{
    public class UpdateToDoCommandModel : ICommandModel
    {
        [Required]
        public Guid Id { get; private set; }
        [Required]
        public string Title { get; protected set; }
        [Required]
        public string Content { get; protected set; }
        [Required]
        public Guid UserId { get; private set; }
        [Required]
        public Guid CardId { get; private set; }

        public UpdateToDoCommandModel SetId(Guid id)
        {
            Id = id;
            return this;
        }

        public UpdateToDoCommandModel SetCardId(Guid cardId)
        {
            CardId = cardId;
            return this;
        }

        public UpdateToDoCommandModel SetUserId(Guid userId)
        {
            UserId = userId;
            return this;
        }
    }
}

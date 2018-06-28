using System;
using System.ComponentModel.DataAnnotations;
using AwesomeToDo.Infrastructure.Commands.Abstract;

namespace AwesomeToDo.Infrastructure.Commands.Models.ToDo
{
    public class AddToDoCommandModel : ICommandModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public Guid UserId { get; private set; }
        [Required]
        public Guid CardId { get; private set; }

        public AddToDoCommandModel SetCardId(Guid cardId)
        {
            CardId = cardId;
            return this;
        }

        public AddToDoCommandModel SetUserId(Guid userId)
        {
            UserId = userId;
            return this;
        }
    }
}

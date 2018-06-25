using System;
using System.ComponentModel.DataAnnotations;
using AwesomeToDo.Infrastructure.Commands.Abstract;

namespace AwesomeToDo.Infrastructure.Commands.Models.Card
{
    public class AddCardCommandModel : ICommandModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public Guid UserId { get; private set; }

        public AddCardCommandModel SetUserId(Guid userId)
        {
            UserId = userId;
            return this;
        }
    }
}

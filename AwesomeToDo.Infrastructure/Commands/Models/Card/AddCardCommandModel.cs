using System;
using AwesomeToDo.Infrastructure.Commands.Abstract;

namespace AwesomeToDo.Infrastructure.Commands.Models.Card
{
    public class AddCardCommandModel : ICommandModel
    {
        public string Title { get; set; }
        public Guid UserId { get; set; }

        public AddCardCommandModel SetUserId(Guid userId)
        {
            UserId = userId;
            return this;
        }
    }
}

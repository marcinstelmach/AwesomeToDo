using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using AwesomeToDo.Infrastructure.Commands.Abstract;

namespace AwesomeToDo.Infrastructure.Commands.Models.Card
{
    public class UpdateCardCommandModel : ICommandModel
    {
        [Required]
        public Guid Id { get; private set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public Guid UserId { get; private set; }

        public UpdateCardCommandModel SetId(Guid id)
        {
            Id = id;
            return this;
        }

        public UpdateCardCommandModel SetUserId(Guid userId)
        {
            UserId = userId;
            return this;
        }
    }
}

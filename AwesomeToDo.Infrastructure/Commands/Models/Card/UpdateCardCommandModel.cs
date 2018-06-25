using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using AwesomeToDo.Infrastructure.Commands.Abstract;

namespace AwesomeToDo.Infrastructure.Commands.Models.Card
{
    public class UpdateCardCommandModel : ICommandModel
    {
        public Guid Id { get; set; }
        [Required]
        public string Title { get; set; }
        public Guid UserId { get; set; }

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

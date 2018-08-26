using System;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace AwesomeToDo.Infrastructure.Requests.Models.Cards
{
    public class AddCardRequestModel : IRequest
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public Guid UserId { get; private set; }

        public AddCardRequestModel SetUserId(Guid userId)
        {
            UserId = userId;
            return this;
        }
    }
}

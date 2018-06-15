using System;
using System.ComponentModel.DataAnnotations;
using AwesomeToDo.Infrastructure.Commands.Abstract;

namespace AwesomeToDo.Infrastructure.Commands.Models.User
{
    public class LoginUserCommandModel : ICommandModel
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        public Guid TokenId { get; set; }
    }
}

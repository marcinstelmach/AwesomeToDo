using System.ComponentModel.DataAnnotations;
using AwesomeToDo.Infrastructure.Commands.Abstract;

namespace AwesomeToDo.Infrastructure.Commands.Models.User
{
    public class AddUserCommandModel : ICommandModel
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string ConfirmPassword { get; set; }
    }
}

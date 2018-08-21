using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;
using MediatR;

namespace AwesomeToDo.Infrastructure.Requests.Models.Users
{
    public class AddUserRequestModel : IRequest
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
        [Compare(nameof(Password))]
        public string ConfirmPassword { get; set; }
    }
}

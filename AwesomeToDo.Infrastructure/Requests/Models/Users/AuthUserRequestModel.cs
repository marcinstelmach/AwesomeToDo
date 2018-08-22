using System.ComponentModel.DataAnnotations;
using AwesomeToDo.Infrastructure.Dto.Token;
using MediatR;

namespace AwesomeToDo.Infrastructure.Requests.Models.Users
{
    public class AuthUserRequestModel : IRequest<TokenDto>
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}

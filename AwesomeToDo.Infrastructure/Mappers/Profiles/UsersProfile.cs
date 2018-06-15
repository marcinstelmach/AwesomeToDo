using AutoMapper;
using AwesomeToDo.Domain.Entities;
using AwesomeToDo.Infrastructure.Dto.User;

namespace AwesomeToDo.Infrastructure.Mappers.Profiles
{
    public class UsersProfile : Profile
    {
        public UsersProfile() 
            : base("Users")
        {
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"));
        }
    }
}

using AutoMapper;
using AwesomeToDo.Domain.Entities;
using AwesomeToDo.Infrastructure.Dto.ToDo;

namespace AwesomeToDo.Infrastructure.Mappers.Profiles
{
    public class ToDosProfile : Profile
    {
        public ToDosProfile() 
            : base("ToDo")
        {
            CreateMap<ToDo, ToDoDto>()
                .ForMember(dest => dest.CreationDateTime, opt => opt.MapFrom(src => src.CreationDateTime.ToString("G")))
                .ForMember(dest => dest.LastModified, opt => opt.MapFrom(src => src.LastModified.ToString("G")));
        }
    }
}

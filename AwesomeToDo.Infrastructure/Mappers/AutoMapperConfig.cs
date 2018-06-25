using AutoMapper;
using AwesomeToDo.Infrastructure.Mappers.Profiles;

namespace AwesomeToDo.Infrastructure.Mappers
{
    public class AutoMapperConfig
    {
        public static IMapper Initialize()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new UsersProfile());
                cfg.AddProfile(new CardsProfile());
                cfg.AddProfile(new ToDosProfile());
            })
            .CreateMapper();
        }
    }
}

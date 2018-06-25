using AutoMapper;
using AwesomeToDo.Domain.Entities;
using AwesomeToDo.Infrastructure.Dto.Card;

namespace AwesomeToDo.Infrastructure.Mappers.Profiles
{
    public class CardsProfile : Profile
    {
        public CardsProfile()
            : base("Cards")
        {
            CreateMap<Card, CardDto>();
        }
    }
}

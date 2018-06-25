using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using AwesomeToDo.Domain.Repositories.Abstract;
using AwesomeToDo.Infrastructure.Dto.User;
using AwesomeToDo.Infrastructure.Services.Abstract.Queries;

namespace AwesomeToDo.Infrastructure.Services.Concrete.Queries
{
    public class UserQueryService : IUserQueryService
    {
        private readonly IUserRepository userRepository;
        private readonly IMapper mapper;

        public UserQueryService(IUserRepository userRepository, IMapper mapper)
        {
            this.userRepository = userRepository;
            this.mapper = mapper;
        }

        public async Task<IList<UserDto>> Get()
            => mapper.Map<IList<UserDto>>(await userRepository.GetAsync());

        public async Task<UserDto> Get(Guid id)
            => mapper.Map<UserDto>(await userRepository.GetAsync(id));
    }
}

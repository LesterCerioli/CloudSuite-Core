using AutoMapper;
using CloudSuite.Domain.Contracts;
using CloudSuite.Domain.Models;
using CloudSuite.Domain.ValueObjects;
using CloudSuite.Modules.Application.Handlers.User;
using CloudSuite.Modules.Application.Services.Contracts;
using CloudSuite.Modules.Application.ViewModels;
using NetDevPack.Mediator;

namespace CloudSuite.Modules.Application.Services.Implementations
{
	public class UserAppService : IUserAppService
	{
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;

        public UserAppService(
            IUserRepository userRepository,
            IMediatorHandler mediator,
            IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<UserViewModel> GetByCpf(Cpf cpf)
		{
			return _mapper.Map<UserViewModel>(await _userRepository.GetByCpf(cpf));
		}

		public async Task<UserViewModel> GetByEmail(Email email)
		{
			return _mapper.Map<UserViewModel>(await _userRepository.GetByEmail(email));
		}

		public async Task Save(CreateUserCommand commandCreate)
		{
			await _userRepository.Add(commandCreate.GetEntity());
		}
	}
}
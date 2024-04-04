using AutoMapper;
using CloudSuite.Domain.Contracts;
using CloudSuite.Modules.Application.Handlers.Media;
using CloudSuite.Modules.Application.Services.Contracts;
using CloudSuite.Modules.Application.ViewModels;
using NetDevPack.Mediator;

namespace CloudSuite.Modules.Application.Services.Implementations
{
	public class MediaAppService : IMediaAppService
	{
        private readonly IMediaRepository _mediaRepository;
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _mediator;

        public MediaAppService(
            IMediaRepository mediaRepository,
            IMediatorHandler mediator,
            IMapper mapper)
        {
            _mediaRepository = mediaRepository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<MediaViewModel> GetByFileName(string fileName)
		{
			return _mapper.Map<MediaViewModel>(await _mediaRepository.GetByFileName(fileName));
		}

		public async Task<MediaViewModel> GetByFileSize(int? fileSize)
		{
			return _mapper.Map<MediaViewModel>(await _mediaRepository.GetByFileSize(fileSize));
		}

		public async Task Save(CreateMediaCommand commandCreate)
		{
			await _mediaRepository.Add(commandCreate.GetEntity());
		}
	}
}
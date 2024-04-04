using CloudSuite.Domain.Contracts;
using CloudSuite.Modules.Application.Handlers.Media.Responses;
using CloudSuite.Modules.Application.Validations.Media;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace CloudSuite.Modules.Application.Handlers.Media
{
    public class CreateMediaHandler : IRequestHandler<CreateMediaCommand, CreateMediaResponse>
    {
        private readonly IMediaRepository _mediaRepository;
        private readonly ILogger<CreateMediaHandler> _logger;

        public CreateMediaHandler(IMediaRepository mediaRepository, ILogger<CreateMediaHandler> logger)
        {
            _mediaRepository = mediaRepository;
            _logger = logger;
        }
        public async Task<CreateMediaResponse> Handle(CreateMediaCommand command, CancellationToken cancellationToken)
        {

            _logger.LogInformation($"CreateMediaCommand: {JsonSerializer.Serialize(command)}");
            var validationResult = new CreateMediaCommandValidation().Validate(command);

            if (validationResult.IsValid)
            {
                try
                {
                    var mediaCaption = await _mediaRepository.GetByCaption(command.Caption);
                    var mediaFileName = await _mediaRepository.GetByFileName(command.FileName);
                    var mediaFileSize = await _mediaRepository.GetByFileSize(command.FileSize);

                    if (mediaCaption != null && mediaFileName != null && mediaFileSize != null)
                    {
                        return await Task.FromResult(new CreateMediaResponse(command.Id, "Media already registered."));
                    }
                    await _mediaRepository.Add(command.GetEntity());
                    return await Task.FromResult(new CreateMediaResponse(command.Id, validationResult));
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CreateMediaResponse(command.Id, "Failed to process the request."));
                }
            }
            return await Task.FromResult(new CreateMediaResponse(command.Id, validationResult));

        }
    }
}

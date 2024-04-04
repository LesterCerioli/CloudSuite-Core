using CloudSuite.Domain.Contracts;
using CloudSuite.Modules.Application.Handlers.Email.Responses;
using CloudSuite.Modules.Application.Validations.Email;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace CloudSuite.Modules.Application.Handlers.Email
{
    public class CreateEmailHandler : IRequestHandler<CreateEmailCommand, CreateEmailResponse>
    {
        private readonly IEmailRepository _emailRepository;
        private readonly ILogger<CreateEmailHandler> _logger;

        public CreateEmailHandler(IEmailRepository emailRepository, ILogger<CreateEmailHandler> logger)
        {
            _emailRepository = emailRepository;
            _logger = logger;
        }
        public async Task<CreateEmailResponse> Handle(CreateEmailCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CreateEmailCommand: {JsonSerializer.Serialize(command)}");
            var validationResult = new CreateEmailCommandValidation().Validate(command);

            if (validationResult.IsValid)
            {
                try
                {
                    var emailSender = await _emailRepository.GetBySender(command.Sender);
                    var emailRecipient = await _emailRepository.GetByRecipient(command.Recipient);

                    if (emailSender != null && emailRecipient != null)
                    {
                        return await Task.FromResult(new CreateEmailResponse(command.Id, "Email already registered."));
                    }
                    await _emailRepository.Add(command.GetEntity());
                    return await Task.FromResult(new CreateEmailResponse(command.Id, validationResult));
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CreateEmailResponse(command.Id, "Failed to process the request."));
                }
            }
            return await Task.FromResult(new CreateEmailResponse(command.Id, validationResult));
        }
    }
}

using CloudSuite.Domain.Contracts;
using CloudSuite.Modules.Application.Handlers.District.Responses;
using CloudSuite.Modules.Application.Validations.District;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace CloudSuite.Modules.Application.Handlers.District
{
    public class CreateDistrictHandler : IRequestHandler<CreateDistrictCommand, CreateDistrictResponse>
    {
        private readonly IDistrictRepository _districtRepository;
        private readonly ILogger<CreateDistrictHandler> _logger;

        public CreateDistrictHandler(IDistrictRepository districtRepository, ILogger<CreateDistrictHandler> logger)
        {
            _districtRepository = districtRepository;
            _logger = logger;
        }
        public async Task<CreateDistrictResponse> Handle(CreateDistrictCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CreateDistrictCommand: {JsonSerializer.Serialize(command)}");
            var validationResult = new CreateDistrictCommandValidation().Validate(command);

            if (validationResult.IsValid)
            {
                try
                {
                    var countryName = await _districtRepository.GetByName(command.Name);

                    if (countryName != null)
                    {
                        return await Task.FromResult(new CreateDistrictResponse(command.Id, "District already registered."));
                    }
                    await _districtRepository.Add(command.GetEntity());
                    return await Task.FromResult(new CreateDistrictResponse(command.Id, validationResult));
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CreateDistrictResponse(command.Id, "Failed to process the request."));
                }
            }
            return await Task.FromResult(new CreateDistrictResponse(command.Id, validationResult));

        }
    }
}

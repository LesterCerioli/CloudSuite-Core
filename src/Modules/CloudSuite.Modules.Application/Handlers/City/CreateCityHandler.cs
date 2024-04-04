using CloudSuite.Domain.Contracts;
using CloudSuite.Modules.Application.Validations.City;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace CloudSuite.Modules.Application.Hadlers.City
{
    public class CreateCityHandler : IRequestHandler<CreateCityCommand, CreateCityResponse>
    {
        private readonly ICityRepository _cityRepository;
        private readonly ILogger<CreateCityHandler> _logger;

        public CreateCityHandler(ICityRepository cityRepository, ILogger<CreateCityHandler> logger)
        {
            _cityRepository = cityRepository;
            _logger = logger;
        }

        public async Task<CreateCityResponse> Handle(CreateCityCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CreateCityCommand: {JsonSerializer.Serialize(command)}");
            var validationResult = new CreateCityCommandValidation().Validate(command);

            if (validationResult.IsValid)
            {
                try
                {
                    var cityCityName = await _cityRepository.GetByCityName(command.CityName);

                    if (cityCityName == null)
                    {
                        await _cityRepository.Add(command.GetEntity());
                        return new CreateCityResponse(command.Id, validationResult);
                    }

                    return new CreateCityResponse(command.Id, "City already registered"); ;

                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error creating extract");
                    return new CreateCityResponse(command.Id, "Error creating City");
                }
            }
            return new CreateCityResponse(command.Id, validationResult);
        }
    }
}

using CloudSuite.Domain.Contracts;
using CloudSuite.Modules.Application.Hadlers.Address.Responses;
using CloudSuite.Modules.Application.Validations.Address;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace CloudSuite.Modules.Application.Hadlers.Address
{
    public class CreateAddressHandler : IRequestHandler<CreateAddressCommand, CreateAddressResponse>
    {
        private readonly IAddressRepository _addressRepository;
        private readonly ILogger<CreateAddressHandler> _logger;

        public CreateAddressHandler(IAddressRepository adressRepository, ILogger<CreateAddressHandler> logger)
        {
            _addressRepository = adressRepository;
            _logger = logger;
        }

        public async Task<CreateAddressResponse> Handle(CreateAddressCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CreateAddressCommand: {JsonSerializer.Serialize(command)}");
            var validationResult = new CreateAddressCommandValidation().Validate(command);

            if (validationResult.IsValid)
            {
                try
                {
                    var addressAddressLine = await _addressRepository.GetByAddressLine(command.AddressLine1);
                    var addressContactName = await _addressRepository.GetByContactName(command.ContactName);

                    if (addressContactName != null && addressAddressLine != null) {
                        return await Task.FromResult(new CreateAddressResponse(command.Id, "Address already registered!"));
                    }
                    await _addressRepository.Add(command.GetEntity());
                    return await Task.FromResult(new CreateAddressResponse(command.Id, validationResult));
                }
                catch (Exception ex) { 
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CreateAddressResponse(command.Id, "It`s not possible to process your solicitation."));
                }
            }

            return await Task.FromResult(new CreateAddressResponse(command.Id, validationResult));
        }
    }
}
using CloudSuite.Domain.Contracts;
using CloudSuite.Modules.Application.Handlers.Vendor.Responses;
using CloudSuite.Modules.Application.Validations.Vendor;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace CloudSuite.Modules.Application.Handlers.Vendor
{
    public class CreateVendorHandler : IRequestHandler<CreateVendorCommand, CreateVendorResponse>
    {
        private readonly IVendorRepository _vendorRepository;
        private readonly ILogger<CreateVendorHandler> _logger;

        public CreateVendorHandler(IVendorRepository vendorRepository, ILogger<CreateVendorHandler> logger)
        {
            _vendorRepository = vendorRepository;
            _logger = logger;
        }

        public async Task<CreateVendorResponse> Handle(CreateVendorCommand command, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CreateVendorCommand: {JsonSerializer.Serialize(command)}");
            var validationResult = new CreateVendorCommandValidation().Validate(command);

            if (validationResult.IsValid)
            {
                try
                {
                    var vendorCnpj = await _vendorRepository.GetByCnpj(command.Cnpj);
                    var vendorName = await _vendorRepository.GetByName(command.Name);
                    var vendorCreationDate = await _vendorRepository.GetByCreatedOn(command.CreatedOn);

                    if (vendorCnpj != null && vendorName != null && vendorCreationDate != null)
                    {
                        return await Task.FromResult(new CreateVendorResponse(command.Id, "Vendor already registered."));
                    }
                    await _vendorRepository.Add(command.GetEntity());
                    return await Task.FromResult(new CreateVendorResponse(command.Id, validationResult));
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CreateVendorResponse(command.Id, "Failed to process the request."));
                }
            }
            return await Task.FromResult(new CreateVendorResponse(command.Id, validationResult));

        }
    }
}

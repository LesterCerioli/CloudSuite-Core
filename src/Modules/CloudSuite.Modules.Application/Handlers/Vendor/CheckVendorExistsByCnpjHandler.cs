using CloudSuite.Domain.Contracts;
using CloudSuite.Modules.Application.Handlers.Vendor.Request;
using CloudSuite.Modules.Application.Handlers.Vendor.Responses;
using CloudSuite.Modules.Application.Validations.Vendor;
using MediatR;
using Microsoft.Extensions.Logging;
using System.Text.Json;

namespace CloudSuite.Modules.Application.Handlers.Vendor
{
    public class CheckVendorExistsByCnpjHandler : IRequestHandler<CheckVendorExistsByCnpjRequest, CheckVendorExistsByCnpjResponse>
    {
        private readonly IVendorRepository _vendorRepository;
        private readonly ILogger<CheckVendorExistsByCnpjHandler> _logger;
        private string cnpj;

        public CheckVendorExistsByCnpjHandler(string cnpj)
        {
            this.cnpj = cnpj;
        }

        public CheckVendorExistsByCnpjHandler(IVendorRepository vendorRepository, ILogger<CheckVendorExistsByCnpjHandler> logger)
        {
            _vendorRepository = vendorRepository;
            _logger = logger;
        }
        public async Task<CheckVendorExistsByCnpjResponse> Handle(CheckVendorExistsByCnpjRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation($"CheckVendorExistsByCnpjRequest: {JsonSerializer.Serialize(request)}");
            var validationResult = new CheckVendorExistsByCnpjRequestValidation().Validate(request);

            if (validationResult.IsValid)
            {
                try
                {
                    var VendorCnpj = await _vendorRepository.GetByCnpj(request.Cnpj);

                    if (VendorCnpj != null)
                    {
                        return await Task.FromResult(new CheckVendorExistsByCnpjResponse(request.Id, true, validationResult));
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogCritical(ex.Message);
                    return await Task.FromResult(new CheckVendorExistsByCnpjResponse(request.Id, "Failed to process the request."));
                }
            }
            return await Task.FromResult(new CheckVendorExistsByCnpjResponse(request.Id, false, validationResult));

        }
    }
}

using CloudSuite.Modules.Application.Hadlers.Address.Responses;
using MediatR;

namespace CloudSuite.Modules.Application.Hadlers.Address.Requests
{
        public class CheckAddressExistsByAddressLineRequest : IRequest<CheckAddressExistsByAddressLineResponse>
        {
            public Guid Id { get; private set; }

            public string? AddressLine1 { get; set; }

            public CheckAddressExistsByAddressLineRequest(string addressLine1)
            {
                Id = Guid.NewGuid();
                AddressLine1 = addressLine1;
            }
        }
    }
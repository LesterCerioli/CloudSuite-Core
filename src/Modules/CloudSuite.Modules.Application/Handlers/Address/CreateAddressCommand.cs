using CloudSuite.Domain.Models;
using CloudSuite.Modules.Application.Hadlers.Address.Responses;
using MediatR;
using System.ComponentModel.DataAnnotations;
using AddressEntity = CloudSuite.Domain.Models.Address;
using CityEntity = CloudSuite.Domain.Models.City;

namespace CloudSuite.Modules.Application.Hadlers.Address
{
    public class CreateAddressCommand : IRequest<CreateAddressResponse>
    {
            public Guid Id { get; private set; }

            
            public string? ContactName { get; private set; }

            
            public string? AddressLine1 { get; set; }

            
            public AddressEntity GetEntity()
            {
                return new AddressEntity(
                    
                    this.ContactName,
                    this.AddressLine1
                    );
            }
        }

    }
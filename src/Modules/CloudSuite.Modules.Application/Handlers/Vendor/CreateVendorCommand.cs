using CloudSuite.Domain.Models;
using CloudSuite.Domain.ValueObjects;
using CloudSuite.Modules.Application.Handlers.Vendor.Responses;
using MediatR;
using System.ComponentModel.DataAnnotations;
using VendorEntity = CloudSuite.Domain.Models.Vendor;

namespace CloudSuite.Modules.Application.Handlers.Vendor
{
    public class CreateVendorCommand : IRequest<CreateVendorResponse>
    {
        public Guid Id { get; private set; }

        
        public string? Name { get; set; }

        
        public string? Slug { get; set; }

        
        public string? Description { get; set; }

        public string? Cnpj { get; set; }

        
        public DateTimeOffset? CreatedOn { get; set; }

        public DateTimeOffset? LatestUpdatedOn { get; set; }

        public bool? IsActive { get; set; }

        public bool? IsDeleted { get; set; }

        
        public VendorEntity GetEntity()
        {
            return new VendorEntity(
                
                this.Name,
                this.Slug,
                this.Description,
                new Cnpj(this.Cnpj),
                this.CreatedOn,
                this.LatestUpdatedOn,
                this.IsActive.Value,
                this.IsDeleted.Value
                );
        }
    }
}

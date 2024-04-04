using CloudSuite.Modules.Application.Handlers.District.Responses;
using MediatR;
using System.ComponentModel.DataAnnotations;
using DistrictEntity = CloudSuite.Domain.Models.District;

namespace CloudSuite.Modules.Application.Handlers.District
{
    public class CreateDistrictCommand : IRequest<CreateDistrictResponse>
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        
        public string? Type { get; set; }

        
        public string? Location { get; set; }

        public CreateDistrictCommand()
        {
            Id = Guid.NewGuid();
        }

        public DistrictEntity GetEntity()
        {
            return new DistrictEntity(
                
                this.Name,
                this.Type,
                this.Location
                );
        }
    }
}

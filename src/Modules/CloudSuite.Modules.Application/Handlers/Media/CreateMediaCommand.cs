using CloudSuite.Domain.Enums;
using CloudSuite.Modules.Application.Handlers.Media.Responses;
using MediatR;
using System.ComponentModel.DataAnnotations;
using MediaEntity = CloudSuite.Domain.Models.Media;

namespace CloudSuite.Modules.Application.Handlers.Media
{
    public class CreateMediaCommand : IRequest<CreateMediaResponse>
    {
        public Guid Id { get; set; }

        
        public string? Caption { get; set; }

        
        public int? FileSize { get; set; }

        
        public string? FileName { get; set; }

        

        public MediaEntity GetEntity()
        {
            return new MediaEntity(
                
                this.Caption,
                this.FileSize,
                this.FileName
                
                );
        }

    }
}

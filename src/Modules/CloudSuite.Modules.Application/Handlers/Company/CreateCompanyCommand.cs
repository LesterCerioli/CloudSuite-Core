using CloudSuite.Domain.ValueObjects;
using MediatR;
using System.ComponentModel.DataAnnotations;
using CompanyEntity = CloudSuite.Domain.Models.Company;

namespace CloudSuite.Modules.Application.Handlers.Company
{
    public class CreateCompanyCommand : IRequest<CreateCompanyResponse>
    {
        public Guid Id { get; private set; }

        public string? Cnpj { get; set; }
                
        public string? FantasyName { get; set; }

        
        public string? RegisterName { get; set; }

        
        public CreateCompanyCommand()
        {
            Id = Guid.NewGuid();
        }

        public CompanyEntity GetEntity()
        {
            return new CompanyEntity(
                   
                   new Cnpj(this.Cnpj),
                   this.FantasyName,
                   this.RegisterName
                );
        }

    }
}

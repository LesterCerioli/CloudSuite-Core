using CloudSuite.Modules.Application.Hadlers.Address;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.Address
{
    public  class CreateAddressCommandValidation : AbstractValidator<CreateAddressCommand>
    {
        public CreateAddressCommandValidation() 
        {

            RuleFor(a => a.ContactName)
                .NotEmpty()
                .WithMessage("O campo ContactName é obrigatório.")
                .Length(1, 100)
                .WithMessage("O campo ContactName deve ter entre 1 e 60 caracteres.")
                .Matches(@"^[a-zA-Z\s]*$")
                .WithMessage("O campo ContactName deve conter apenas letras e espaços.")
                .NotNull()
                .WithMessage("O campo ContactName não pode ser nulo.");

            RuleFor(a => a.AddressLine1)
                .NotEmpty()
                .WithMessage("O campo AddressLine1 é obrigatório.")
                .Length(1, 450)
                .WithMessage("O campo AddressLine1 deve ter entre 1 e 300 caracteres.")
                .Matches(@"^[a-zA-Z0-9\s,]*$")
                .WithMessage("O campo AddressLine1 deve conter apenas letras, números, espaços e vírgulas.")
                .NotNull()
                .WithMessage("O campo AddressLine1 não pode ser nulo.");
            

        }
    }
}

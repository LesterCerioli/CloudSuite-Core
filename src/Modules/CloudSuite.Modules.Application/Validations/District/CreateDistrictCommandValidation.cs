using CloudSuite.Modules.Application.Handlers.District;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.District
{
    public class CreateDistrictCommandValidation : AbstractValidator<CreateDistrictCommand>
    {
        public CreateDistrictCommandValidation() 
        {
            RuleFor(a => a.Name)
                .NotEmpty()
                .WithMessage("O campo Name é obrigatório.")
                .Length(1, 450)
                .WithMessage("O campo Name deve ter entre 1 e 450 caracteres.")
                .Matches(@"^[a-zA-Z\s]*$")
                .WithMessage("O campo Type deve conter apenas letras e espaços.")
                .NotNull().WithMessage("O campo Type não pode ser nulo.");

            RuleFor(a => a.Type)
                .NotEmpty()
                .WithMessage("O campo Type é obrigatório.")
                .Matches(@"^[a-zA-Z\s]*$")
                .WithMessage("O campo Type deve conter apenas letras e espaços.")
                .NotNull().WithMessage("O campo Type não pode ser nulo.");

            RuleFor(a => a.Location)
                .NotEmpty()
                .WithMessage("O campo Location é obrigatório.")
                .Length(1, 100)
                .WithMessage("O campo Location deve ter entre 1 e 100 caracteres.")
                .Matches(@"^[a-zA-Z0-9\s,]*$")
                .WithMessage("O campo Location deve conter apenas letras, números, espaços e vírgulas.")
                .NotNull()
                .WithMessage("O campo Location não pode ser nulo.");

        }
    }
}

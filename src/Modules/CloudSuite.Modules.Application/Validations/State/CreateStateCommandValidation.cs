using CloudSuite.Modules.Application.Handlers.State;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.State
{
    public class CreateStateCommandValidation : AbstractValidator<CreateStateCommand>
    {
        public CreateStateCommandValidation() 
        {
            RuleFor(a => a.StateName)
               .NotEmpty()
               .WithMessage("O campo StateName é obrigatório.")
               .Length(1, 100)
               .WithMessage("O campo StateName deve ter entre 1 e 100 caracteres.")
               .Matches(@"^[a-zA-Z\s]*$")
               .WithMessage("O campo StateName deve conter apenas letras e espaços.")
               .NotNull()
               .WithMessage("O campo StateName não pode ser nulo.");

            RuleFor(a => a.UF)
                .NotEmpty()
                .WithMessage("O campo UF é obrigatório.")
                .Length(2)
                .Matches(@"^[A-Z]{2}$")
                .WithMessage("O campo UF deve conter exatamente 2 letras maiúsculas.")
                .NotNull()
                .WithMessage("O campo UF não pode ser nulo.");

        }
    }
}

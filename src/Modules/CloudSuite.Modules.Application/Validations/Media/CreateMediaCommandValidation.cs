using CloudSuite.Modules.Application.Handlers.Media;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.Media
{
    public class CreateMediaCommandValidation : AbstractValidator<CreateMediaCommand>
    {
        public CreateMediaCommandValidation() 
        {
            RuleFor(a => a.Caption)
                .NotEmpty()
                .WithMessage("O campo Caption é obrigatório.")
                .Length(1, 450)
                .WithMessage("O campo Caption deve ter entre 1 e 450 caracteres.");

            RuleFor(a => a.FileSize)
                .NotNull()
                .WithMessage("O campo FileSize é obrigatório.")
                .GreaterThanOrEqualTo(0)
                .WithMessage("O campo FileSize deve ser maior ou igual a 0.");

            RuleFor(a => a.FileName)
                .NotEmpty()
                .WithMessage("O campo FileName é obrigatório.")
                .Length(1, 450)
                .WithMessage("O campo FileName deve ter entre 1 e 450 caracteres.");

            
        }
    }
}

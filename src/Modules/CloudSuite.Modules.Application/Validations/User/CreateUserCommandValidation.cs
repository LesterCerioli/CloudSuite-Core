using CloudSuite.Modules.Application.Handlers.User;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.User
{
    public class CreateUserCommandValidation : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidation() 
        {
            RuleFor(a => a.FullName)
               .NotEmpty()
               .WithMessage("O campo FullName é obrigatório.")
               .Length(1, 100)
               .WithMessage("O campo FullName deve ter entre 1 e 100 caracteres.")
               .Matches(@"^[a-zA-Z\s]*$")
               .WithMessage("O campo FullName deve conter apenas letras e espaços.")
               .NotNull()
               .WithMessage("O campo FullName não pode ser nulo.");

                   

            RuleFor(a => a.Cpf)
                .Must(cpf => IsValid(cpf))
                .WithMessage("O campo Cnpj é inválido.");

            RuleFor(a => a.TelephoneNumber)
                .NotEmpty()
                .WithMessage("O preenchimento do telefone é obrigatorio")
                .Length(10, 13)
                .WithMessage("O número de telefone deve ter entre 10 e 13 caracteres.")
                .Matches(@"^[0-9a-zA-Z\s]*$")
                .WithMessage("O número de telefone deve conter apenas números e letras.")
                .NotNull()
                .WithMessage("O número de telefone não pode ser nulo.");

            RuleFor(a => a.TelephoneRegion)
               .Length(1, 3)
               .WithMessage("O campo TelephoneRegion deve ter entre 1 e 3 caracteres.");


            RuleFor(a => a.CreatedOn)
                .LessThanOrEqualTo(DateTimeOffset.Now)
                .WithMessage("O campo CreatedOn deve ser uma data e hora no passado ou presente.");

            RuleFor(a => a.LatestUpdatedOn)
               .GreaterThanOrEqualTo(a => a.CreatedOn)
               .WithMessage("O campo LatestUpdatedOn deve ser uma data e hora no mesmo momento ou depois de CreatedOn.")
               .LessThanOrEqualTo(DateTimeOffset.Now)
               .WithMessage("O campo LatestUpdatedOn deve ser uma data e hora no passado ou presente.");

            RuleFor(a => a.RefreshTokenHash)
                .Length(1, 450)
                .WithMessage("O campo RefreshTokenHash deve ter entre 1 e 450 caracteres.");

            RuleFor(a => a.Culture)
               .Length(1, 450)
               .WithMessage("O campo Culture deve ter entre 1 e 450 caracteres.")
               .NotNull()
               .WithMessage("O campo Culture não pode ser nulo.");

            RuleFor(a => a.ExtensionData)
               .Length(1, 100)
               .WithMessage("O campo ExtensionData deve ter entre 1 e 100 caracteres.")
               .NotNull()
               .WithMessage("O campo ExtensionData não pode ser nulo."); ;
        }

        private bool IsValid(string cpf)
        {
            //Valida��o do CPF
            if (string.IsNullOrWhiteSpace(cpf))
                return false;

            cpf = cpf.Trim().Replace(".", "").Replace("-", "");

            if (cpf.Length != 11)
                return false;

            if (cpf == "00000000000" || cpf == "11111111111" || cpf == "22222222222" || cpf == "33333333333" || cpf == "44444444444" || cpf == "55555555555" || cpf == "66666666666" || cpf == "77777777777" || cpf == "88888888888" || cpf == "99999999999")
                return false;

            var sum = 0;
            var rest = 0;
            for (var i = 1; i <= 9; i++)
                sum = sum + int.Parse(cpf[i - 1].ToString()) * (11 - i);
            rest = (sum * 10) % 11;

            if ((rest == 10) || (rest == 11))
                rest = 0;
            if (rest != int.Parse(cpf[9].ToString()))
                return false;

            sum = 0;
            for (var i = 1; i <= 10; i++)
                sum = sum + int.Parse(cpf[i - 1].ToString()) * (12 - i);
            rest = (sum * 10) % 11;

            if ((rest == 10) || (rest == 11))
                rest = 0;
            if (rest != int.Parse(cpf[10].ToString()))
                return false;

            return true;
        }
    }
}

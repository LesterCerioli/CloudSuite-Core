using CloudSuite.Modules.Application.Handlers.Vendor;
using FluentValidation;

namespace CloudSuite.Modules.Application.Validations.Vendor
{
    public class CreateVendorCommandValidation : AbstractValidator<CreateVendorCommand>
    {
        public CreateVendorCommandValidation()
        {
            RuleFor(a => a.Name)
               .NotEmpty()
               .WithMessage("O campo Name é obrigatório.")
               .Length(1, 450)
               .WithMessage("O campo Name deve ter entre 1 e 450 caracteres.")
               .Matches(@"^[a-zA-Z\s]*$")
               .WithMessage("O campo Name deve conter apenas letras e espaços.")
               .NotNull()
               .WithMessage("O campo Name não pode ser nulo.");

            RuleFor(a => a.Slug)
               .NotEmpty()
               .WithMessage("O campo Slug é obrigatório.")
               .Length(1, 450)
               .WithMessage("O campo Slug deve ter entre 1 e 450 caracteres.")
               .NotNull()
               .WithMessage("O campo Slug não pode ser nulo.");

            RuleFor(a => a.Description)
               .Length(1, 100)
               .WithMessage("O campo Description deve ter entre 1 e 100 caracteres.");

            RuleFor(a => a.CreatedOn)
                .LessThanOrEqualTo(DateTimeOffset.Now)
                .WithMessage("O campo CreatedOn deve ser uma data e hora no passado ou presente.");

            RuleFor(a => a.LatestUpdatedOn)
               .GreaterThanOrEqualTo(a => a.CreatedOn)
               .WithMessage("O campo LatestUpdatedOn deve ser uma data e hora no mesmo momento ou depois de CreatedOn.")
               .LessThanOrEqualTo(DateTimeOffset.Now)
               .WithMessage("O campo LatestUpdatedOn deve ser uma data e hora no passado ou presente.");

            RuleFor(a => a.Cnpj)
                .Must(cnpj => IsValidCnpj(cnpj))
                .WithMessage("O campo Cnpj é inválido.");

        }

        private bool IsValidCnpj(string cnpj)
        {
            if (string.IsNullOrWhiteSpace(cnpj))
                return false;

            // Remove non-digit characters
            cnpj = cnpj.Trim().Replace(".", "").Replace("-", "").Replace("/", "");

            // CNPJ must have 14 digits
            if (cnpj.Length != 14)
                return false;

            // Check for repeated digits or invalid checksum
            if (IsRepeatedDigits(cnpj) || !IsValidChecksum(cnpj))
                return false;

            return true;
        }

        private bool IsRepeatedDigits(string cnpjNumber)
        {
            return cnpjNumber == new string(cnpjNumber[0], 14);
        }

        // Private method to validate the CNPJ checksum
        private bool IsValidChecksum(string cnpjNumber)
        {
            var sum = 0;
            var multiplier = 5;

            // Calculate the first checksum digit
            for (int i = 0; i < 12; i++)
            {
                sum += int.Parse(cnpjNumber[i].ToString()) * multiplier;
                multiplier = (multiplier == 2) ? 9 : multiplier - 1;
            }

            var remainder = sum % 11;
            var digit1 = (remainder < 2) ? 0 : 11 - remainder;

            sum = 0;
            multiplier = 6;

            // Calculate the second checksum digit
            for (int i = 0; i < 13; i++)
            {
                sum += int.Parse(cnpjNumber[i].ToString()) * multiplier;
                multiplier = (multiplier == 2) ? 9 : multiplier - 1;
            }

            remainder = sum % 11;
            var digit2 = (remainder < 2) ? 0 : 11 - remainder;

            // Compare the calculated checksum digits with the provided ones
            return (int.Parse(cnpjNumber[12].ToString()) == digit1) && (int.Parse(cnpjNumber[13].ToString()) == digit2);
        }

        private bool IsValidCpf(string cpf)
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

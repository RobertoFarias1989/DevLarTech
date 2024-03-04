using DevLarTech.Application.Commands.CreateTelephone;
using DevLarTech.Core.Enums;
using FluentValidation;
using System.Text.RegularExpressions;

namespace DevLarTech.Application.Validators
{
    public class CreateTelephoneCommandValidator : AbstractValidator<CreateTelephoneCommand>
    {
        public CreateTelephoneCommandValidator()
        {
            RuleFor(t=> t.TelephoneNumber)
                .MaximumLength(50)
                 .WithMessage("Tamanho máximo do número de telefone é 50 caracteres.");

            RuleFor(t => t.TelephoneNumber)
           .Must(ValidPhoneNumber)
           .WithMessage("Número de telefone inválido.");

            RuleFor(t => t.Type)
                .IsEnumName(typeof(TelephoneTypeEnum), caseSensitive: true)
                .WithMessage("Informe um tipo de telefone válido.");

        }

        private bool ValidPhoneNumber(string phoneNumber)
        {

            var regex = new Regex(@"^\d{11}$");

            return regex.IsMatch(phoneNumber);
        }
    }
}

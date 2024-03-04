using DevLarTech.Application.Commands.UpdateTelephone;
using DevLarTech.Core.Enums;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DevLarTech.Application.Validators
{
    public class UpdateTelephoneCommandValidator : AbstractValidator<UpdateTelephoneCommand>
    {
        public UpdateTelephoneCommandValidator()
        {
            RuleFor(t => t.TelephoneNumber)
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

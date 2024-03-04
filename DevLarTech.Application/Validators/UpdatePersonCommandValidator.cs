using DevLarTech.Application.Commands.UpdatePerson;
using FluentValidation;

namespace DevLarTech.Application.Validators
{
    public class UpdatePersonCommandValidator : AbstractValidator<UpdatePersonCommand>
    {
        public UpdatePersonCommandValidator()
        {
            RuleFor(p => p.FullName)
                .MaximumLength(255)
                .WithMessage("Tamanho máximo do Nome é de 255 caracteres.");
        }
    }
}

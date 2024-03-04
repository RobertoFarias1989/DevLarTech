using DevLarTech.Application.Commands.CreatePerson;
using FluentValidation;

namespace DevLarTech.Application.Validators
{
    public class CreatePersonCommandValidator : AbstractValidator<CreatePersonCommand>
    {
        public CreatePersonCommandValidator()
        {
            RuleFor(p=> p.FullName)
                .MaximumLength(255)
                .WithMessage("Tamanho máximo do Nome é de 255 caracteres.");
        }
    }
}

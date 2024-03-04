using DevLarTech.Core.Entities;
using DevLarTech.Core.Enums;
using DevLarTech.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevLarTech.Application.Commands.CreateTelephone
{
    public class CreateTelephoneCommandHandler : IRequestHandler<CreateTelephoneCommand, Unit>
    {
        private readonly IPersonRepository _personRepository;

        public CreateTelephoneCommandHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<Unit> Handle(CreateTelephoneCommand request, CancellationToken cancellationToken)
        {
            var phone = new Telephone(
               (TelephoneTypeEnum)Enum.Parse(typeof(TelephoneTypeEnum), request.Type),       
                request.TelephoneNumber,
                request.IdPerson);

            await _personRepository.AddTelephoneAsync(phone);

            return Unit.Value;
        }
    }
}

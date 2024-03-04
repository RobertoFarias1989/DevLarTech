using DevLarTech.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevLarTech.Application.Commands.UpdateTelephone
{
    public class UpdateTelephoneCommandHandler : IRequestHandler<UpdateTelephoneCommand, Unit>
    {
        private readonly IPersonRepository _personRepository;

        public UpdateTelephoneCommandHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<Unit> Handle(UpdateTelephoneCommand request, CancellationToken cancellationToken)
        {
            var telephone = await _personRepository.GetTelephoneByIdAsync(request.Id);

            telephone.Update(request.Type,request.TelephoneNumber);

            await _personRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}

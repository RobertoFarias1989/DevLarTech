using DevLarTech.Application.ViewModels;
using DevLarTech.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevLarTech.Application.Queries.GetPersonById
{
    public class GetPersonByIdQueryHandler : IRequestHandler<GetPersonByIdQuery, PersonDetailsViewModel>
    {
        private readonly IPersonRepository _personRepository;

        public GetPersonByIdQueryHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<PersonDetailsViewModel> Handle(GetPersonByIdQuery request, CancellationToken cancellationToken)
        {
            var person = await _personRepository.GetDetailsByIdAsync(request.Id);

            if(person == null) return null;

            var telephoneViewModel = person.Telephones
                .Where(t => t.IdPerson == person.Id)
                .Select(t => new TelephoneViewModel
                {
                    Id = t.Id,
                    Type = t.Type.ToString(),
                    TelephoneNumber = t.TelephoneNumber,
                    IdPerson = t.IdPerson,
                    CreatedAt = t.CreatedAt
                }).ToList();

            var personDetailsViewModel = new PersonDetailsViewModel(
                person.Id,
                person.FullName,
                person.BirthDate,
                person.CreatedAt,
                person.Active,
                telephoneViewModel);

            return personDetailsViewModel;
        }
    }
}

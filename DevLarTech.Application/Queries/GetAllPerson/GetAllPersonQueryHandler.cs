using DevLarTech.Application.ViewModels;
using DevLarTech.Core.Repositories;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevLarTech.Application.Queries.GetAllPerson
{
    public class GetAllPersonQueryHandler : IRequestHandler<GetAllPersonQuery, List<PersonViewModel>>
    {
        private readonly IPersonRepository _personRepository;

        public GetAllPersonQueryHandler(IPersonRepository personRepository)
        {
            _personRepository = personRepository;
        }

        public async Task<List<PersonViewModel>> Handle(GetAllPersonQuery request, CancellationToken cancellationToken)
        {
            var person = await _personRepository.GetAllAsync();

            var personViewModel = person
                .Select(p => new PersonViewModel(p.Id, p.FullName, p.BirthDate))
                .ToList();

            return personViewModel;
        }
    }
}

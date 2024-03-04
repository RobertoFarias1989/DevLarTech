using DevLarTech.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevLarTech.Application.Queries.GetPersonById
{
    public class GetPersonByIdQuery : IRequest<PersonDetailsViewModel>
    {
        public GetPersonByIdQuery(int id)
        {
            Id = id;
        }
        public int Id { get; private set; }
    }
}

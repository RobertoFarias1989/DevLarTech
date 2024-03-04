using DevLarTech.Application.ViewModels;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevLarTech.Application.Queries.GetAllPerson
{
    public class GetAllPersonQuery : IRequest<List<PersonViewModel>>
    {
        public GetAllPersonQuery(string query)
        {
            Query = query;
        }
        public string Query { get; private set; }
    }
}

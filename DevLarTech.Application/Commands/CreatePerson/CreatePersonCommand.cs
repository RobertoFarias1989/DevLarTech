using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevLarTech.Application.Commands.CreatePerson
{
    public class CreatePersonCommand : IRequest<int>
    {
        public string FullName { get;  set; }
        public DateTime BirthDate { get;  set; }
    }
}

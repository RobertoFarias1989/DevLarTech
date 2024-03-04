using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevLarTech.Application.Commands.DeletePerson
{
    public class DeletePersonCommand : IRequest<Unit>
    {
        public DeletePersonCommand(int id)
        {
            Id = id;
        }

        public int Id { get; private set; }
    }
}

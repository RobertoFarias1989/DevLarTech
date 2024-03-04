using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevLarTech.Application.Commands.UpdateTelephone
{
    public class UpdateTelephoneCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public string TelephoneNumber { get;  set; }
    }
}

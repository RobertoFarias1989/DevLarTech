using DevLarTech.Core.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevLarTech.Application.Commands.CreateTelephone
{
    public class CreateTelephoneCommand : IRequest<Unit>
    {
        public string Type { get;  set; }

        //public TelephoneTypeEnum Type { get;  set; }
        public string TelephoneNumber { get;  set; }
        public int IdPerson { get;  set; }
    }
}

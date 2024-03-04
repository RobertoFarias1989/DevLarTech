using DevLarTech.Application.Commands.UpdateTelephone;
using DevLarTech.Core.Entities;
using DevLarTech.Core.Enums;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevLarTech.Application.Commands.UpdatePerson
{
    public class UpdatePersonCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string FullName { get;  set; }
        public DateTime BirthDate { get;  set; }

    }
}

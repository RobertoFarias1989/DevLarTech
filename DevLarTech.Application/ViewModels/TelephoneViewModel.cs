using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevLarTech.Application.ViewModels
{
    public class TelephoneViewModel
    {

        public int Id { get;  set; }
        public string Type { get; set; }
        public string TelephoneNumber { get;  set; }
        public int IdPerson { get;  set; }
        public DateTime CreatedAt { get;  set; }
    }
}

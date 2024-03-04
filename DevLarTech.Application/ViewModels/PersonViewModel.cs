using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevLarTech.Application.ViewModels
{
    public class PersonViewModel
    {
        public PersonViewModel(int id, string fullName, DateTime birthDate)
        {
            Id = id;
            FullName = fullName;
            BirthDate = birthDate;
        }

        public int Id { get; set; }
        public string FullName { get; private set; }
        public DateTime BirthDate { get; private set; }
    }
}

using DevLarTech.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevLarTech.Application.ViewModels
{
    public class PersonDetailsViewModel
    {
        public PersonDetailsViewModel(int id,
            string fullName, 
            DateTime birthDate, 
            DateTime createdAt, 
            bool active, 
            List<TelephoneViewModel> telephones)
        {
            Id = id;
            FullName = fullName;
            BirthDate = birthDate;
            CreatedAt = createdAt;
            Active = active;
            Telephones = telephones;
        }

        public int Id { get;  set; }
        public string FullName { get; private set; }
        public DateTime BirthDate { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool Active { get; private set; }
        public List<TelephoneViewModel> Telephones { get; private set; }
    }
}

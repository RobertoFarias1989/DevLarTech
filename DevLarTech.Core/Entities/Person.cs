using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevLarTech.Core.Entities
{
    public class Person : BaseEntity
    {
        public Person(string fullName, DateTime birthDate)
        {
            FullName = fullName;
            BirthDate = birthDate;           
            

            CreatedAt = DateTime.Now;
            Active = true;
            Telephones = new List<Telephone>();
        }

        public string FullName { get; private set; }
        public DateTime BirthDate { get; private set; }
        public DateTime CreatedAt { get; private set; }
        public bool Active { get; private set; }
        public List<Telephone> Telephones { get; private set; }

        public void Update(string fullName, DateTime birthDate)
        {
            FullName = fullName;
            BirthDate = birthDate;
        }

        public void Inactived()
        {
            if (Active == true)
                Active = false;
        }
    }
}

using DevLarTech.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevLarTech.Core.Entities
{
    public class Telephone : BaseEntity
    {
        public Telephone(TelephoneTypeEnum type, string telephoneNumber, int idPerson)
        {
            Type = type;
            TelephoneNumber = telephoneNumber;
            IdPerson = idPerson;

            CreatedAt = DateTime.Now;
        }

        public TelephoneTypeEnum Type { get; private set; }
        public string TelephoneNumber { get; private set; }
        public int IdPerson { get; private set; }
        public Person Person{ get; private set; }
        public DateTime CreatedAt { get; private set; }

        public void Update(string type, string telephoneNumber)
        {
            Type = (TelephoneTypeEnum)Enum.Parse(typeof(TelephoneTypeEnum), type);
            TelephoneNumber = telephoneNumber;
        }

    }
}

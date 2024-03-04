using DevLarTech.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevLarTech.Core.Repositories
{
    public interface IPersonRepository
    {
        Task<List<Person>> GetAllAsync();
        Task<Person> GetByIdAsync(int id);
        Task<Telephone> GetTelephoneByIdAsync(int id);
        Task<Person> GetDetailsByIdAsync(int id);
        Task AddAsync(Person person);
        Task AddTelephoneAsync(Telephone telephone);
        Task SaveChangesAsync();

    }
}

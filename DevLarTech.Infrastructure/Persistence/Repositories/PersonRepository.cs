using DevLarTech.Core.Entities;
using DevLarTech.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevLarTech.Infrastructure.Persistence.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        private readonly DevLarTechDbContext _dbContext;

        public PersonRepository(DevLarTechDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Person>> GetAllAsync()
        {
            return await _dbContext.People.ToListAsync();
        }

        public async Task<Person> GetByIdAsync(int id)
        {
            return await _dbContext.People
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Person> GetDetailsByIdAsync(int id)
        {
            return await _dbContext
                .People
                .Include(p => p.Telephones)
                .SingleOrDefaultAsync(p => p.Id == id);
        }

        public async Task<Telephone> GetTelephoneByIdAsync(int id)
        {
            return await _dbContext.Telephones
                .SingleOrDefaultAsync(t => t.Id == id);
        }

        public async Task AddAsync(Person person)
        {
            await _dbContext.People.AddAsync(person);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddTelephoneAsync(Telephone telephone)
        {
            await _dbContext.Telephones.AddAsync(telephone);
            await _dbContext.SaveChangesAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

    }
}

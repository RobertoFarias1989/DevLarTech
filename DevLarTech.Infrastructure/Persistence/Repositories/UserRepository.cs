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
    public class UserRepository : IUserRepository
    {
        private readonly DevLarTechDbContext _dbContext;
        public UserRepository(DevLarTechDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddUserAsync(User user)
        {
            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<bool> ExistsByEmailOrFullNameAsync(string email, string fullName)
        {
            var normalizedEmail = email.ToLowerInvariant();
            var normalizedFullName = fullName.ToLowerInvariant();

            return await _dbContext.Users
                .AnyAsync(u => u.Email.ToLower() == normalizedEmail || u.FullName.ToLower() == normalizedFullName);
        }

        public async Task<User> GetByIdAsync(int id)
        {
            //SingleOrDefault garante que na base não há Ids duplicados;
            return await _dbContext.Users.SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<User> GetUserByEmailAndPasswordAsync(string email, string passwordHash)
        {
            return await _dbContext.
                Users.
                SingleOrDefaultAsync(u => u.Email == email && u.Password == passwordHash);


        }
    }
}

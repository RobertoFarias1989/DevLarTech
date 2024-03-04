using DevLarTech.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DevLarTech.Infrastructure.Persistence
{
    public class DevLarTechDbContext : DbContext
    {
        public DevLarTechDbContext(DbContextOptions<DevLarTechDbContext> options) : base(options)
        {

        }

        public DbSet<User> Users { get; set; }
        public DbSet<Person> People { get; set; }

        public DbSet<Telephone> Telephones  { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}

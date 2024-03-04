using DevLarTech.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevLarTech.Infrastructure.Persistence.Configurations
{
    public class TelephoneConfigurations : IEntityTypeConfiguration<Telephone>
    {
        public void Configure(EntityTypeBuilder<Telephone> builder)
        {
            builder
                .HasKey(t => t.Id);

            builder
           .Property(t => t.TelephoneNumber)
           .HasMaxLength(50);

            builder
                .HasOne(t => t.Person)
                .WithMany(t => t.Telephones)
                .HasForeignKey(t => t.IdPerson);

            builder
                .Property(t => t.Type)
                .HasConversion(typeof(string))
                .HasMaxLength(20);
        }
    }
}

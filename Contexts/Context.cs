using Microsoft.EntityFrameworkCore;
using SNMedicTreatment.Models.Entity;
using SNMedicTreatment.Models.Events;
using SNMedicTreatment.Models.Medications;
using SNMedicTreatment.Models.Patients;
using SNMedicTreatment.Models.Tokens;
using SNMedicTreatment.Models.Treatments;
using SNMedicTreatment.Models.Users;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SNMedicTreatment.Contexts
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        {

        }

        // Objeto novo / variavel
        public DbSet<User> Users { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Medication> Medications { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<RefreshToken>().HasKey(vf => new { vf.Id, vf.IdUser });
        }

        public override int SaveChanges()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().IsSubclassOf(typeof(BaseDB))))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("CreatedAt").CurrentValue = DateTime.UtcNow;
                    entry.Property("UpdatedAt").CurrentValue = DateTime.UtcNow;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("UpdatedAt").CurrentValue = DateTime.UtcNow;
                }
            }
            return base.SaveChanges();
        }

    }
}

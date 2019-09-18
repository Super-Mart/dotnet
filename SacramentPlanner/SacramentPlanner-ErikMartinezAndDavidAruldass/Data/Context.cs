using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SacramentPlanner_ErikMartinezAndDavidAruldass.Models;

namespace SacramentPlanner.Models
{
    public class Context : DbContext
    {
        public Context (DbContextOptions<Context> options)
            : base(options)
        {
        }

        public DbSet<Member> Member { get; set; }

        public DbSet<Bishopric> Bishopric { get; set; }

        public DbSet<Hymn> Hymn { get; set; }

        public DbSet<Speaker> Speaker { get; set; }

        public DbSet<SacramentSchedule> SacramentSchedule { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                entityType.GetForeignKeys()
                    .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade)
                    .ToList()
                    .ForEach(fk => fk.DeleteBehavior = DeleteBehavior.Restrict);
            }
        }
    }
}

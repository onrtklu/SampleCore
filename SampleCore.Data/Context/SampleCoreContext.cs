using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using SampleCore.Core.Entities;

namespace SampleCore.Data.Context
{
    public class SampleCoreContext : DbContext
    {
        public SampleCoreContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<SampleCoreEntity> SampleCoreEntity { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.ConfigureWarnings(w => w.Ignore(CoreEventId.LazyLoadOnDisposedContextWarning));

            base.OnConfiguring(optionsBuilder);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

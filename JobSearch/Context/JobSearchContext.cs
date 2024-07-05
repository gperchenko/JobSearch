using Microsoft.EntityFrameworkCore;
using JobSearch.DBModels;

namespace JobSearch.Context
{
    public class JobSearchContext : DbContext
    {
        public DbSet<Profile> Profiles { get; set; }

        public JobSearchContext(DbContextOptions<JobSearchContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

           builder.Entity<Profile>()
                .ToTable("Profile");
        }

        public override int SaveChanges()
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is EntityBasse && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified));
            foreach (var entityEntry in entries)
            {
                ((EntityBasse)entityEntry.Entity).UpdatedDate = DateTime.Now;
                if (entityEntry.State == EntityState.Added)
                {
                    ((EntityBasse)entityEntry.Entity).CreatedDate = DateTime.Now;
                }
            }
            return base.SaveChanges();
        }
    }
}

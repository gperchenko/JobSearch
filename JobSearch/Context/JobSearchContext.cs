using Microsoft.EntityFrameworkCore;
using JobSearch.DBModels;

namespace JobSearch.Context
{
    public class JobSearchContext : DbContext
    {
        public DbSet<Profile> Profiles { get; set; }
        public DbSet<Resume> Resumes { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Activity> Activities { get; set; }

        public JobSearchContext(DbContextOptions<JobSearchContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Profile>()
                .ToTable("Profile");

            builder.Entity<Profile>()
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Entity<Resume>()
                .ToTable("Resume");

            builder.Entity<Resume>()
                .Property(r => r.FileName)
                .IsRequired()
                .HasMaxLength(150);

            builder.Entity<Resume>()
                .Property(r => r.Description)
                .HasMaxLength(150);

            builder.Entity<Contact>()
               .ToTable("Contact");

            builder.Entity<Contact>()
                .Property(c => c.FirstName)
                .HasMaxLength(50);

            builder.Entity<Contact>()
                .Property(c => c.LastName)
                .HasMaxLength(50);

            builder.Entity<Contact>()
                .Property(c => c.Email)
                .HasMaxLength(50);

            builder.Entity<Contact>()
                .Property(c => c.Phone)
                .HasMaxLength(50);

            builder.Entity<Contact>()
                .Property(c => c.CompanyName)
                .HasMaxLength(150);

            builder.Entity<Activity>()
               .ToTable("Activity");

            builder.Entity<Activity>()
                .Property(a => a.Description)
                .HasMaxLength(100);

            builder.Entity<Activity>()
                .Property(a => a.Note)
                .HasMaxLength(250);

            builder.Entity<Activity>()
                .HasOne(a => a.RecruiterContact)
                .WithMany(c => c.AcivitiesByRecruiter)
                .HasForeignKey(a => a.RecruiterContactId);

            builder.Entity<Activity>()
                .HasOne(a => a.CompanyContact)
                .WithMany(c => c.ActivitiesByCompany)
                .HasForeignKey(a => a.CompanyContactId);

        }


        public sealed override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            var entries = ChangeTracker
                .Entries()
                .Where(e => e.Entity is EntityBase && (
                        e.State == EntityState.Added
                        || e.State == EntityState.Modified));
            foreach (var entityEntry in entries)
            {
                ((EntityBase)entityEntry.Entity).UpdatedDate = DateTime.Now;
                if (entityEntry.State == EntityState.Added)
                {
                    ((EntityBase)entityEntry.Entity).CreatedDate = DateTime.Now;
                }
            }
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}

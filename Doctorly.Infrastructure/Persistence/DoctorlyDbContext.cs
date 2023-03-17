using Doctorly.Domain.AggregatesModel.AttendeeAggregate;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Doctorly.Infrastructure.Persistence
{
    public class DoctorlyDbContext : DbContext, IDoctorlyDbContext
    {
        public DbSet<Attendee> Attendees { get; set; }
        public DbSet<Event> Events { get; set; }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        public DoctorlyDbContext(DbContextOptions<DoctorlyDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }
    }
}

using Doctorly.Domain.AggregatesModel.AttendeeAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Doctorly.Infrastructure.EntityTypeConfigurations
{
    public class EventEntityTypeConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.HasKey(x => x.Id);

            builder.HasOne(x => x.Attendee)
                   .WithMany(x => x.Events)
                   .HasForeignKey(x => x.AttendeeId);

            builder.Property(x => x.Title)
                   .IsRequired()
                   .HasMaxLength(50);

            builder.Property(x => x.Title)
                   .HasMaxLength(500);

            builder.Property(x => x.StartTime)
                   .IsRequired()
                   .HasMaxLength(10);

            builder.Property(x => x.EndTime)
                   .IsRequired()
                   .HasMaxLength(10);

            builder.Property(x => x.EventDate)
                   .IsRequired();
        }
    }
}

using Doctorly.Domain.AggregatesModel.AttendeeAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Doctorly.Infrastructure.EntityTypeConfigurations
{
    public class AttendeeEntityTypeConfiguration : IEntityTypeConfiguration<Attendee>
    {
        public void Configure(EntityTypeBuilder<Attendee> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(100);

            builder.OwnsOne(x => x.Email)
                   .Property(x => x.Value)
                   .IsRequired()    
                   .HasColumnName("Email")
                   .HasMaxLength(70);

            builder.HasMany(x => x.Events)
                   .WithOne(x => x.Attendee)
                   .HasForeignKey(x => x.AttendeeId)
                   .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

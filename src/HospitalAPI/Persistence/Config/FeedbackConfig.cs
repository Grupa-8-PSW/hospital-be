using HospitalLibrary.Feedback;
using HospitalLibrary.Patient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HospitalAPI.Persistence.Config
{
    public class FeedbackConfig : IEntityTypeConfiguration<Feedback>
    {
        public void Configure(EntityTypeBuilder<Feedback> builder)
        {
            builder.Property(f => f.Text)
                .IsRequired()
                .HasMaxLength(255);

            builder.Property(f => f.Rating)
                .IsRequired();

            builder.Property(f => f.IsAnonymous)
                .IsRequired();

            builder.Property(f => f.Status)
                .IsRequired();

            builder.Property(f => f.IsPublic)
                .IsRequired();

            builder.Property(f => f.CreationDate)
                .IsRequired();

            builder.HasOne(f => f.Patient)
                .WithMany(p => p.Feedbacks)
                .HasForeignKey(p => p.PatientId)
                .IsRequired();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniApp1.Entities;

namespace UniApp1.Contexts.Configurations
{
    public class AssignmentConfiguration : IEntityTypeConfiguration<Assignment>
    {
        public void Configure(EntityTypeBuilder<Assignment> builder)
        {
            builder.HasKey(a => a.AssignmentId);

            builder.HasOne(x => x.Course)
             .WithMany(x => x.Assignments)
               .HasForeignKey(x => x.CourseId);
        }
    }
}
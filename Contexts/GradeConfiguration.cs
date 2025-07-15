using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniApp1.Entities;

namespace UniApp1.Contexts.Configurations
{
    public class GradeConfiguration : IEntityTypeConfiguration<Grade>
    {
        public void Configure(EntityTypeBuilder<Grade> builder)
        {
            {
                builder.HasKey(g => g.GradeId);

                builder.HasOne(x => x.Assignment)
                 .WithOne(x => x.Grade)
                   .HasForeignKey<Grade>(x => x.AssignmentId);

                builder.HasOne(x => x.User)
                .WithMany(x => x.Grades)
                  .HasForeignKey(x => x.StudentId);
            }
        }
    }
}
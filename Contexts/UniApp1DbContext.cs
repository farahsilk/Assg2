using Microsoft.EntityFrameworkCore;
using UniApp1.Contexts.Configurations;

namespace UniApp1.Contexts
{
    public class UniApp1DbContext : DbContext
    {
        public DbSet<Entities.Course> Courses { get; set; }
        public DbSet<Entities.Assignment> Assignments { get; set; }
        public DbSet<Entities.Comment> Comments { get; set; }
        public DbSet<Entities.Grade> Grades { get; set; }
        public DbSet<Entities.Syllabus> Syllabus { get; set; }
        public DbSet<Entities.User> Users { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlServer("Server=localhost;Database=University;Trusted_Connection=True;TrustServerCertificate=True");
        }
        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new AssignmentConfiguration());
            builder.ApplyConfiguration(new CommentConfiguration());
            builder.ApplyConfiguration(new CourseConfiguration());
            builder.ApplyConfiguration(new GradeConfiguration());
            builder.ApplyConfiguration(new UserConfiguration());

        }


    }
}
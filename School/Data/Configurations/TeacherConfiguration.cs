using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Models;

namespace School.Data.Configurations
{
    public class TeacherConfiguration : IEntityTypeConfiguration<Teacher>
    {
        public void Configure(EntityTypeBuilder<Teacher> builder)
        {
            builder.HasOne(a => a.ClassRoom).WithOne(x => x.Teacher).HasForeignKey<ClassRoom>(x => x.TeacherId);
            builder.Property(b => b.FullName).IsRequired().HasMaxLength(20);
        }
    }
}
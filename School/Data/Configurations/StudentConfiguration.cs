using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Models;

namespace School.Data.Configurations
{
    public class StudentConfiguration : IEntityTypeConfiguration<Student>
    {
        public void Configure(EntityTypeBuilder<Student> builder)
        {
            builder.HasOne(a => a.ClassRoom).WithMany(x => x.Students).HasForeignKey(x => x.ClassRoomId);
            builder.Property(b => b.FullName).IsRequired().HasMaxLength(20);
        }
    }
}
using Microsoft.EntityFrameworkCore;
using School.Models;

namespace School.Data.Seeds
{
    internal static class TeacherSeed
    {
        internal static ModelBuilder AddTeacherSeedData(this ModelBuilder builder)
        {
            var teachers = new Teacher[]
            {
                new Teacher
                {
                    Id = 1,
                    FullName = "Жан Дарм",
                    Phone = "078945688",
                },
                new Teacher
                {
                    Id = 2,
                    FullName = "Клод Дарм",
                    Phone = "078945688",
                },
            };

            builder.Entity<Teacher>().HasData(teachers);

            return builder;
        }
    }
}
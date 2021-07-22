using Microsoft.EntityFrameworkCore;
using School.Models;

namespace School.Data.Seeds
{
    internal static class ClassRoomSeed
    {
        internal static ModelBuilder AddClassRoomSeedData(this ModelBuilder builder)
        {
            var classRooms = new ClassRoom[]
            {
                new ClassRoom
                {
                    Id = 1,
                    Name = "11 A",
                    TeacherId = 1
                },
                new ClassRoom
                {
                    Id = 2,
                    Name = "11 Б",
                    TeacherId = 2
                },
            };

            builder.Entity<ClassRoom>().HasData(classRooms);

            return builder;
        }
    }
}
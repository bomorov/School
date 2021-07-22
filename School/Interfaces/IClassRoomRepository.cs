using Microsoft.EntityFrameworkCore;
using School.Data;
using School.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace School.Interfaces
{
    public interface IClassRoomRepository
    {
        Task<List<ClassRoom>> ClassRoomList();

        Task Create(ClassRoom classRoom);

        Task Edit(ClassRoom classRoom);

        Task Delete(int id);
    }

    public class ClassRoomRepository : IClassRoomRepository
    {
        private readonly ApplicationDbContext _context;

        public ClassRoomRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<ClassRoom>> ClassRoomList()
        {
            return await _context.ClassRooms.Include(x => x.Teacher).Include(x => x.Students).ToListAsync();
        }

        public async Task Create(ClassRoom classRoom)
        {
            _context.ClassRooms.Add(classRoom);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(ClassRoom classRoom)
        {
            _context.ClassRooms.Update(classRoom);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var classRoom = await _context.ClassRooms.FirstOrDefaultAsync(x => x.Id == id); ;
            _context.ClassRooms.Remove(classRoom);
            await _context.SaveChangesAsync();
        }
    }
}
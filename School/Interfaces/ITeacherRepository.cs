using Microsoft.EntityFrameworkCore;
using School.Data;
using School.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace School.Interfaces
{
    public interface ITeacherRepository
    {
        Task<List<Teacher>> TeacherList();

        Task Create(Teacher teacher);

        Task Edit(Teacher teacher);

        Task Delete(int id);
    }

    public class TeacherRepository : ITeacherRepository
    {
        private readonly ApplicationDbContext _context;

        public TeacherRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Teacher>> TeacherList()
        {
            return await _context.Teachers.Include(x => x.ClassRoom).ToListAsync();
        }

        public async Task Create(Teacher teacher)
        {
            _context.Teachers.Add(teacher);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(Teacher teacher)
        {
            _context.Teachers.Update(teacher);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var teacher = await _context.Teachers.FirstOrDefaultAsync(x => x.Id == id); ;
            _context.Teachers.Remove(teacher);
            await _context.SaveChangesAsync();
        }
    }
}
using Microsoft.EntityFrameworkCore;
using School.Data;
using School.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace School.Interfaces
{
    public interface IStudentRepository
    {
        Task Create(Student student);

        Task Edit(Student student);

        Task<List<Student>> StudentList();

        Task Delete(int id);
    }

    public class StudentRepository : IStudentRepository
    {
        private readonly ApplicationDbContext _context;

        public StudentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<Student>> StudentList()
        {
            return await _context.Students.Include(x => x.ClassRoom).Include(x => x.ClassRoom.Teacher).ToListAsync();
        }

        public async Task Create(Student student)
        {
            _context.Students.Add(student);
            await _context.SaveChangesAsync();
        }

        public async Task Edit(Student student)
        {
            _context.Update(student);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var student = await _context.Students.FirstOrDefaultAsync(x => x.Id == id); ;
            _context.Students.Remove(student);
            await _context.SaveChangesAsync();
        }
    }
}
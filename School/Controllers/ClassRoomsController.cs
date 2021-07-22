using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using School.Data;
using School.Interfaces;
using School.Models;
using System.Linq;
using System.Threading.Tasks;

namespace School.Controllers
{
    public class ClassRoomsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IClassRoomRepository _classRoomRepository;

        public ClassRoomsController(ApplicationDbContext context, IClassRoomRepository classRoomRepository)
        {
            _context = context;
            _classRoomRepository = classRoomRepository;
        }

        // GET: ClassRooms
        public async Task<IActionResult> Index()
        {
            return View(await _classRoomRepository.ClassRoomList());
        }

        // GET: ClassRooms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classRoom = await _context.ClassRooms
                .Include(c => c.Teacher).Include(x => x.Students)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (classRoom == null)
            {
                return NotFound();
            }

            return View(classRoom);
        }

        // GET: ClassRooms/Create
        public IActionResult Create()
        {
            ViewData["TeacherId"] = new SelectList(_context.Set<Teacher>(), "Id", "FullName");
            return View();
        }

        // POST: ClassRooms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ClassRoom classRoom)
        {
            if (ModelState.IsValid)
            {
                await _classRoomRepository.Create(classRoom);
                return RedirectToAction(nameof(Index));
            }
            ViewData["TeacherId"] = new SelectList(_context.Set<Teacher>(), "Id", "FullName", classRoom.TeacherId);
            return View(classRoom);
        }

        // GET: ClassRooms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classRoom = await _context.ClassRooms.FindAsync(id);
            if (classRoom == null)
            {
                return NotFound();
            }
            ViewData["TeacherId"] = new SelectList(_context.Set<Teacher>(), "Id", "FullName", classRoom.TeacherId);
            return View(classRoom);
        }

        // POST: ClassRooms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ClassRoom classRoom)
        {
            if (id != classRoom.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _classRoomRepository.Edit(classRoom);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClassRoomExists(classRoom.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["TeacherId"] = new SelectList(_context.Teachers, "Id", "Name");
            return View(classRoom);
        }

        // GET: ClassRooms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var classRoom = await _context.ClassRooms
                .Include(c => c.Teacher)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (classRoom == null)
            {
                return NotFound();
            }

            return View(classRoom);
        }

        // POST: ClassRooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _classRoomRepository.Delete(id);
            return RedirectToAction(nameof(Index));
        }

        private bool ClassRoomExists(int id)
        {
            return _context.ClassRooms.Any(e => e.Id == id);
        }
    }
}
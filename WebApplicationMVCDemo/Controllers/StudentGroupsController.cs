using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplicationMVCDemo.Data;
using WebApplicationMVCDemo.Models;

namespace WebApplicationMVCDemo.Controllers
{
    public class StudentGroupsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public StudentGroupsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: StudentGroups
        public async Task<IActionResult> Index()
        {
              return _context.StudentGroup != null ? 
                          View(await _context.StudentGroup.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.StudentGroup'  is null.");
        }

        // GET: StudentGroups/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.StudentGroup == null)
            {
                return NotFound();
            }

            var studentGroup = await _context.StudentGroup.Include(s=>s.Students)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentGroup == null)
            {
                return NotFound();
            }

            return View(studentGroup);
        }

        // GET: StudentGroups/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: StudentGroups/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] StudentGroup studentGroup)
        {
            if (ModelState.IsValid)
            {
                _context.Add(studentGroup);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(studentGroup);
        }

        // GET: StudentGroups/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.StudentGroup == null)
            {
                return NotFound();
            }

            var studentGroup = await _context.StudentGroup.FindAsync(id);
            if (studentGroup == null)
            {
                return NotFound();
            }
            return View(studentGroup);
        }

        // POST: StudentGroups/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] StudentGroup studentGroup)
        {
            if (id != studentGroup.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(studentGroup);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StudentGroupExists(studentGroup.Id))
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
            return View(studentGroup);
        }

        // GET: StudentGroups/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.StudentGroup == null)
            {
                return NotFound();
            }

            var studentGroup = await _context.StudentGroup
                .FirstOrDefaultAsync(m => m.Id == id);
            if (studentGroup == null)
            {
                return NotFound();
            }

            return View(studentGroup);
        }

        // POST: StudentGroups/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.StudentGroup == null)
            {
                return Problem("Entity set 'ApplicationDbContext.StudentGroup'  is null.");
            }
            var studentGroup = await _context.StudentGroup.FindAsync(id);
            if (studentGroup != null)
            {
                _context.StudentGroup.Remove(studentGroup);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool StudentGroupExists(int id)
        {
          return (_context.StudentGroup?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoreInde.Data;
using CoreInde.Models;
using CoreInde.Dtos;
using AutoMapper;

namespace CoreInde.Controllers
{
    public class EmpSkillsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public EmpSkillsController(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: EmpSkills
        public async Task<IActionResult> Index()
        {

            var employeesItems = _context.Employees.Include(s => s.Skills).ToList();

            return View(_mapper.Map<IEnumerable<EmployeesReadDto>>(employeesItems));

        }

        // GET: EmpSkills/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empSkills = await _context.EmpSkills
                .Include(e => e.Employees3)
                .Include(e => e.Skills3)
                .FirstOrDefaultAsync(m => m.Employee3Id == id);
            if (empSkills == null)
            {
                return NotFound();
            }

            return View(empSkills);
        }

        // GET: EmpSkills/Create
        public IActionResult Create()
        {
            ViewData["Employee3Id"] = new SelectList(_context.Employees, "Id", "FistName");
            ViewData["Skills3Id"] = new SelectList(_context.Skills, "Id", "Name");
            return View();
        }

        // POST: EmpSkills/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EmpSkillDate,Employee3Id,Skills3Id")] EmpSkills empSkills)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empSkills);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Employee3Id"] = new SelectList(_context.Employees, "Id", "FistName", empSkills.Employee3Id);
            ViewData["Skills3Id"] = new SelectList(_context.Skills, "Id", "Name", empSkills.Skills3Id);
            return View(empSkills);
        }

        // GET: EmpSkills/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empSkills = await _context.EmpSkills.FindAsync(id);
            if (empSkills == null)
            {
                return NotFound();
            }
            ViewData["Employee3Id"] = new SelectList(_context.Employees, "Id", "FistName", empSkills.Employee3Id);
            ViewData["Skills3Id"] = new SelectList(_context.Skills, "Id", "Description", empSkills.Skills3Id);
            return View(empSkills);
        }

        // POST: EmpSkills/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("EmpSkillDate,Employee3Id,Skills3Id")] EmpSkills empSkills)
        {
            if (id != empSkills.Employee3Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empSkills);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpSkillsExists(empSkills.Employee3Id))
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
            ViewData["Employee3Id"] = new SelectList(_context.Employees, "Id", "FistName", empSkills.Employee3Id);
            ViewData["Skills3Id"] = new SelectList(_context.Skills, "Id", "Description", empSkills.Skills3Id);
            return View(empSkills);
        }

        // GET: EmpSkills/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var empSkills = await _context.EmpSkills
                .Include(e => e.Employees3)
                .Include(e => e.Skills3)
                .FirstOrDefaultAsync(m => m.Employee3Id == id);
            if (empSkills == null)
            {
                return NotFound();
            }

            return View(empSkills);
        }

        // POST: EmpSkills/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var empSkills = await _context.EmpSkills.FindAsync(id);
            _context.EmpSkills.Remove(empSkills);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpSkillsExists(int id)
        {
            return _context.EmpSkills.Any(e => e.Employee3Id == id);
        }
    }
}

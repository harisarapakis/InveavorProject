using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CoreInde.Data;
using CoreInde.Models;
using System.Data;
using ClosedXML.Excel;
using System.IO;

namespace CoreInde.Controllers
{
    public class SkillsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SkillsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Commandss
        public async Task<IActionResult> Index()
        {
            return View(await _context.Skills.ToListAsync());
        }

        // GET: Commandss/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var skill = await _context.Skills
                .FirstOrDefaultAsync(m => m.Id == id);
            if (skill == null)
            {
                return NotFound();
            }

            return View(skill);
        }

        // GET: Commandss/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Commandss/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Skill,DateOfSkillCreation,Description")] Skills command)
        {
            if (ModelState.IsValid)
            {
                _context.Add(command);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(command);
        }

        // GET: Commandss/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var command = await _context.Skills.FindAsync(id);
            if (command == null)
            {
                return NotFound();
            }
            return View(command);
        }

        // POST: Commandss/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Skill,DateOfSkillCreation,Description")] Skills command)
        {
            if (id != command.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(command);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommandExists(command.Id))
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
            return View(command);
        }

        // GET: Commandss/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var command = await _context.Skills
                .FirstOrDefaultAsync(m => m.Id == id);
            if (command == null)
            {
                return NotFound();
            }

            return View(command);
        }

        // POST: Commandss/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var command = await _context.Skills.FindAsync(id);
            _context.Skills.Remove(command);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Export()
        {
            DataTable dt = new DataTable("Grid");
            dt.Columns.AddRange(new DataColumn[4] { new DataColumn("Id"),
                                        new DataColumn("Name"),
                                        new DataColumn("DateOfSkillCreation"),
                                        new DataColumn("Description") });

            var skills = from skill in this._context.Skills.Take(10)
                         select skill;

            foreach (var skill in skills)
            {
                dt.Rows.Add(skill.Id, skill.Name, skill.DateOfSkillCreation, skill.Description);
            }

            using (XLWorkbook wb = new XLWorkbook())
            {
                wb.Worksheets.Add(dt);
                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "Grid.xlsx");
                }
            }
        }

        private bool CommandExists(int id)
        {
            return _context.Skills.Any(e => e.Id == id);
        }





    }
}

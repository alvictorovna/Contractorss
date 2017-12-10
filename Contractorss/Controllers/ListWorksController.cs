using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Contractorss;

namespace Contractorss.Models
{
    public class ListWorksController : Controller
    {
        private readonly ContractorsContext _context;

        public ListWorksController(ContractorsContext context)
        {
            _context = context;
        }

        // GET: ListWorks
        public async Task<IActionResult> Index()
        {
            var contractorsContext = _context.ListWork.Include(l => l.MainObjectIdNavigation).Include(l => l.TypesJobIdNavigation);
            return View(await contractorsContext.ToListAsync());
        }

        // GET: ListWorks/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listWork = await _context.ListWork
                .Include(l => l.MainObjectIdNavigation)
                .Include(l => l.TypesJobIdNavigation)
                .SingleOrDefaultAsync(m => m.ListWorkId == id);
            if (listWork == null)
            {
                return NotFound();
            }

            return View(listWork);
        }

        // GET: ListWorks/Create
        public IActionResult Create()
        {
            ViewData["MainObjectId"] = new SelectList(_context.MainObjects, "MainObjectId", "NameObject");
            ViewData["TypesJobId"] = new SelectList(_context.TypesJobs, "TypesJobId", "Name");
            return View();
        }

        // POST: ListWorks/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ListWorkId,TypesJobId,MainObjectId")] ListWork listWork)
        {
            if (ModelState.IsValid)
            {
                _context.Add(listWork);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MainObjectId"] = new SelectList(_context.MainObjects, "MainObjectId", "NameObject", listWork.MainObjectId);
            ViewData["TypesJobId"] = new SelectList(_context.TypesJobs, "TypesJobId", "Name", listWork.TypesJobId);
            return View(listWork);
        }

        // GET: ListWorks/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listWork = await _context.ListWork.SingleOrDefaultAsync(m => m.ListWorkId == id);
            if (listWork == null)
            {
                return NotFound();
            }
            ViewData["MainObjectId"] = new SelectList(_context.MainObjects, "MainObjectId", "NameObject", listWork.MainObjectId);
            ViewData["TypesJobId"] = new SelectList(_context.TypesJobs, "TypesJobId", "Name", listWork.TypesJobId);
            return View(listWork);
        }

        // POST: ListWorks/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ListWorkId,TypesJobId,MainObjectId")] ListWork listWork)
        {
            if (id != listWork.ListWorkId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(listWork);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ListWorkExists(listWork.ListWorkId))
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
            ViewData["MainObjectId"] = new SelectList(_context.MainObjects, "MainObjectId", "NameObject", listWork.MainObjectId);
            ViewData["TypesJobId"] = new SelectList(_context.TypesJobs, "TypesJobId", "Name", listWork.TypesJobId);
            return View(listWork);
        }

        // GET: ListWorks/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var listWork = await _context.ListWork
                .Include(l => l.MainObjectIdNavigation)
                .Include(l => l.TypesJobIdNavigation)
                .SingleOrDefaultAsync(m => m.ListWorkId == id);
            if (listWork == null)
            {
                return NotFound();
            }

            return View(listWork);
        }

        // POST: ListWorks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var listWork = await _context.ListWork.SingleOrDefaultAsync(m => m.ListWorkId == id);
            _context.ListWork.Remove(listWork);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ListWorkExists(int id)
        {
            return _context.ListWork.Any(e => e.ListWorkId == id);
        }
    }
}

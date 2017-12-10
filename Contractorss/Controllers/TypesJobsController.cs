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
    public class TypesJobsController : Controller
    {
        private readonly ContractorsContext _context;

        public TypesJobsController(ContractorsContext context)
        {
            _context = context;
        }

        // GET: TypesJobs
        public async Task<IActionResult> Index()
        {
            var contractorsContext = _context.TypesJobs.Include(t => t.ContractorIdNavigation).Include(t => t.LicenseIdNavigation);
            return View(await contractorsContext.ToListAsync());
        }

        // GET: TypesJobs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typesJob = await _context.TypesJobs
                .Include(t => t.ContractorIdNavigation)
                .Include(t => t.LicenseIdNavigation)
                .SingleOrDefaultAsync(m => m.TypesJobId == id);
            if (typesJob == null)
            {
                return NotFound();
            }

            return View(typesJob);
        }

        // GET: TypesJobs/Create
        public IActionResult Create()
        {
            ViewData["ContractorId"] = new SelectList(_context.Contractors, "ContractorId", "NameCompany");
            ViewData["LicenseId"] = new SelectList(_context.Licenses, "LicenseId", "Number");
            return View();
        }

        // POST: TypesJobs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TypesJobId,Name,LicenseId,ContractorId,Price")] TypesJob typesJob)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typesJob);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ContractorId"] = new SelectList(_context.Contractors, "ContractorId", "NameCompany", typesJob.ContractorId);
            ViewData["LicenseId"] = new SelectList(_context.Licenses, "LicenseId", "Number", typesJob.LicenseId);
            return View(typesJob);
        }

        // GET: TypesJobs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typesJob = await _context.TypesJobs.SingleOrDefaultAsync(m => m.TypesJobId == id);
            if (typesJob == null)
            {
                return NotFound();
            }
            ViewData["ContractorId"] = new SelectList(_context.Contractors, "ContractorId", "NameCompany", typesJob.ContractorId);
            ViewData["LicenseId"] = new SelectList(_context.Licenses, "LicenseId", "Number", typesJob.LicenseId);
            return View(typesJob);
        }

        // POST: TypesJobs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TypesJobId,Name,LicenseId,ContractorId,Price")] TypesJob typesJob)
        {
            if (id != typesJob.TypesJobId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typesJob);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypesJobExists(typesJob.TypesJobId))
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
            ViewData["ContractorId"] = new SelectList(_context.Contractors, "ContractorId", "NameCompany", typesJob.ContractorId);
            ViewData["LicenseId"] = new SelectList(_context.Licenses, "LicenseId", "Number", typesJob.LicenseId);
            return View(typesJob);
        }

        // GET: TypesJobs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var typesJob = await _context.TypesJobs
                .Include(t => t.ContractorIdNavigation)
                .Include(t => t.LicenseIdNavigation)
                .SingleOrDefaultAsync(m => m.TypesJobId == id);
            if (typesJob == null)
            {
                return NotFound();
            }

            return View(typesJob);
        }

        // POST: TypesJobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var typesJob = await _context.TypesJobs.SingleOrDefaultAsync(m => m.TypesJobId == id);
            _context.TypesJobs.Remove(typesJob);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypesJobExists(int id)
        {
            return _context.TypesJobs.Any(e => e.TypesJobId == id);
        }
    }
}

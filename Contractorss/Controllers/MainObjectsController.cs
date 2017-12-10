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
    public class MainObjectsController : Controller
    {
        private readonly ContractorsContext _context;

        public MainObjectsController(ContractorsContext context)
        {
            _context = context;
        }

        // GET: MainObjects
        public async Task<IActionResult> Index()
        {
            var contractorsContext = _context.MainObjects.Include(m => m.ContractorIdNavigation).Include(m => m.CustomerIdNavigation);
            return View(await contractorsContext.ToListAsync());
        }

        // GET: MainObjects/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mainObject = await _context.MainObjects
                .Include(m => m.ContractorIdNavigation)
                .Include(m => m.CustomerIdNavigation)
                .SingleOrDefaultAsync(m => m.MainObjectId == id);
            if (mainObject == null)
            {
                return NotFound();
            }

            return View(mainObject);
        }

        // GET: MainObjects/Create
        public IActionResult Create()
        {
            ViewData["ContractorId"] = new SelectList(_context.Contractors, "ContractorId", "NameCompany");
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CompanyName");
            return View();
        }

        // POST: MainObjects/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MainObjectId,NameObject,CustomerId,ContractorId,ConclusionContract,DeliveryObject,DateInputObject")] MainObject mainObject)
        {
            if (ModelState.IsValid)
            {
                _context.Add(mainObject);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ContractorId"] = new SelectList(_context.Contractors, "ContractorId", "NameCompany", mainObject.ContractorId);
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CompanyName", mainObject.CustomerId);
            return View(mainObject);
        }

        // GET: MainObjects/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mainObject = await _context.MainObjects.SingleOrDefaultAsync(m => m.MainObjectId == id);
            if (mainObject == null)
            {
                return NotFound();
            }
            ViewData["ContractorId"] = new SelectList(_context.Contractors, "ContractorId", "NameCompany", mainObject.ContractorId);
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CompanyName", mainObject.CustomerId);
            return View(mainObject);
        }

        // POST: MainObjects/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MainObjectId,NameObject,CustomerId,ContractorId,ConclusionContract,DeliveryObject,DateInputObject")] MainObject mainObject)
        {
            if (id != mainObject.MainObjectId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(mainObject);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MainObjectExists(mainObject.MainObjectId))
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
            ViewData["ContractorId"] = new SelectList(_context.Contractors, "ContractorId", "NameCompany", mainObject.ContractorId);
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "CompanyName", mainObject.CustomerId);
            return View(mainObject);
        }

        // GET: MainObjects/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var mainObject = await _context.MainObjects
                .Include(m => m.ContractorIdNavigation)
                .Include(m => m.CustomerIdNavigation)
                .SingleOrDefaultAsync(m => m.MainObjectId == id);
            if (mainObject == null)
            {
                return NotFound();
            }

            return View(mainObject);
        }

        // POST: MainObjects/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var mainObject = await _context.MainObjects.SingleOrDefaultAsync(m => m.MainObjectId == id);
            _context.MainObjects.Remove(mainObject);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MainObjectExists(int id)
        {
            return _context.MainObjects.Any(e => e.MainObjectId == id);
        }
    }
}

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
    public class TechnicalEquipmentsController : Controller
    {
        private readonly ContractorsContext _context;

        public TechnicalEquipmentsController(ContractorsContext context)
        {
            _context = context;
        }

        // GET: TechnicalEquipments
        public async Task<IActionResult> Index()
        {
            var contractorsContext = _context.TechnicalEquipments.Include(t => t.ContractorIdNavigation);
            return View(await contractorsContext.ToListAsync());
        }

        // GET: TechnicalEquipments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var technicalEquipment = await _context.TechnicalEquipments
                .Include(t => t.ContractorIdNavigation)
                .SingleOrDefaultAsync(m => m.TechnicalEquipmentId == id);
            if (technicalEquipment == null)
            {
                return NotFound();
            }

            return View(technicalEquipment);
        }

        // GET: TechnicalEquipments/Create
        public IActionResult Create()
        {
            ViewData["ContractorId"] = new SelectList(_context.Contractors, "ContractorId", "NameCompany");
            return View();
        }

        // POST: TechnicalEquipments/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TechnicalEquipmentId,Denotation,Appointment,DatePurchase,LifetimeYear,ContractorId")] TechnicalEquipment technicalEquipment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(technicalEquipment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ContractorId"] = new SelectList(_context.Contractors, "ContractorId", "NameCompany", technicalEquipment.ContractorId);
            return View(technicalEquipment);
        }

        // GET: TechnicalEquipments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var technicalEquipment = await _context.TechnicalEquipments.SingleOrDefaultAsync(m => m.TechnicalEquipmentId == id);
            if (technicalEquipment == null)
            {
                return NotFound();
            }
            ViewData["ContractorId"] = new SelectList(_context.Contractors, "ContractorId", "NameCompany", technicalEquipment.ContractorId);
            return View(technicalEquipment);
        }

        // POST: TechnicalEquipments/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TechnicalEquipmentId,Denotation,Appointment,DatePurchase,LifetimeYear,ContractorId")] TechnicalEquipment technicalEquipment)
        {
            if (id != technicalEquipment.TechnicalEquipmentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(technicalEquipment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TechnicalEquipmentExists(technicalEquipment.TechnicalEquipmentId))
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
            ViewData["ContractorId"] = new SelectList(_context.Contractors, "ContractorId", "NameCompany", technicalEquipment.ContractorId);
            return View(technicalEquipment);
        }

        // GET: TechnicalEquipments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var technicalEquipment = await _context.TechnicalEquipments
                .Include(t => t.ContractorIdNavigation)
                .SingleOrDefaultAsync(m => m.TechnicalEquipmentId == id);
            if (technicalEquipment == null)
            {
                return NotFound();
            }

            return View(technicalEquipment);
        }

        // POST: TechnicalEquipments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var technicalEquipment = await _context.TechnicalEquipments.SingleOrDefaultAsync(m => m.TechnicalEquipmentId == id);
            _context.TechnicalEquipments.Remove(technicalEquipment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TechnicalEquipmentExists(int id)
        {
            return _context.TechnicalEquipments.Any(e => e.TechnicalEquipmentId == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Contractorss;
using Contractorss.ViewModels;
using PagedList;
using PagedList.Mvc;

namespace Contractorss.Models
{
    public class BuildingMaterialsController : Controller
    {
        private readonly ContractorsContext _context;


        public BuildingMaterialsController(ContractorsContext context)
        {
            _context = context;
        }


        // GET: BuildingMaterials
        public async Task<IActionResult> Index(int? contr, string nameMaterial, SortBuild sortBuild = SortBuild.nameASC, int page=1)
        {
           
            int pageSize = 10;
            IQueryable<BuildingMaterial> building = _context.BuildingMaterials.Include(b => b.ContractorIdNavigation)
                .Include(b => b.ManufacturerIdNavigation);

            if (contr != null && contr != 0)
            {
                building = building.Where(p => p.ContractorId == contr);
            }
            if (!String.IsNullOrEmpty(nameMaterial))
            {
                building = building.Where(p => p.NameMaterial.Contains(nameMaterial));
            }


            switch (sortBuild)
            {
                case SortBuild.nameDSC:
                    building = building.OrderByDescending(s => s.NameMaterial);
                    break;
                case SortBuild.manufacDSC:
                    building = building.OrderByDescending(s => s.ManufacturerIdNavigation.ManufacturerName);
                        break;
                case SortBuild.manufacASC:
                    building = building.OrderBy(s => s.ManufacturerIdNavigation.ManufacturerName);
                    break;
                case SortBuild.voluemDSC:
                    building = building.OrderByDescending(s => s.VolumePurchaseQuantity);
                    break;
                case SortBuild.voluemASC:
                    building = building.OrderBy(s => s.VolumePurchaseQuantity);
                    break;
                case SortBuild.contracDSC:
                    building = building.OrderByDescending(s => s.ContractorIdNavigation.NameCompany);
                    break;
                case SortBuild.contracASC:
                    building = building.OrderBy(s => s.ContractorIdNavigation.NameCompany);
                    break;
                default:
                    building = building.OrderBy(s => s.NameMaterial);
                    break;
            }

            // пагинация
            var count = await building.CountAsync();
            var items = await building.Skip((page - 1) * pageSize).Take(pageSize).ToListAsync();

            // формируем модель представления
            BuildingViewModel viewModel = new BuildingViewModel
            {
                PageViewModel = new PageViewModel(count, page, pageSize),
                SortViewModel = new SortViewModels(sortBuild),
                FilterViewModel = new FilterViewModel(_context.Contractors.ToList(), contr, nameMaterial),
                BuildingMaterials = items
            };
            return View(viewModel); 
        }

        // GET: BuildingMaterials/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buildingMaterial = await _context.BuildingMaterials
                .Include(b => b.ContractorIdNavigation)
                .Include(b => b.ManufacturerIdNavigation)
                .SingleOrDefaultAsync(m => m.BuildingMaterialId == id);
            if (buildingMaterial == null)
            {
                return NotFound();
            }

            return View(buildingMaterial);
        }

       

        // GET: BuildingMaterials/Create
        public IActionResult Create()
        {
            ViewData["ContractorId"] = new SelectList(_context.Contractors, "ContractorId", "NameCompany");
            ViewData["ManufacturerId"] = new SelectList(_context.Manufacturers, "ManufacturerId", "ManufacturerName");
            return View();
        }

        // POST: BuildingMaterials/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BuildingMaterialId,NameMaterial,ManufacturerId,VolumePurchaseQuantity,ContractorId")] BuildingMaterial buildingMaterial)
        {
            if (ModelState.IsValid)
            {
                _context.Add(buildingMaterial);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ContractorId"] = new SelectList(_context.Contractors, "ContractorId", "NameCompany", buildingMaterial.ContractorId);
            ViewData["ManufacturerId"] = new SelectList(_context.Manufacturers, "ManufacturerId", "ManufacturerName", buildingMaterial.ManufacturerId);
            return View(buildingMaterial);
        }

        // GET: BuildingMaterials/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buildingMaterial = await _context.BuildingMaterials.SingleOrDefaultAsync(m => m.BuildingMaterialId == id);
            if (buildingMaterial == null)
            {
                return NotFound();
            }
            ViewData["ContractorId"] = new SelectList(_context.Contractors, "ContractorId", "NameCompany", buildingMaterial.ContractorId);
            ViewData["ManufacturerId"] = new SelectList(_context.Manufacturers, "ManufacturerId", "ManufacturerName", buildingMaterial.ManufacturerId);
            return View(buildingMaterial);
        }

        // POST: BuildingMaterials/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BuildingMaterialId,NameMaterial,ManufacturerId,VolumePurchaseQuantity,ContractorId")] BuildingMaterial buildingMaterial)
        {
            if (id != buildingMaterial.BuildingMaterialId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(buildingMaterial);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BuildingMaterialExists(buildingMaterial.BuildingMaterialId))
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
            ViewData["ContractorId"] = new SelectList(_context.Contractors, "ContractorId", "NameCompany", buildingMaterial.ContractorId);
            ViewData["ManufacturerId"] = new SelectList(_context.Manufacturers, "ManufacturerId", "ManufacturerName", buildingMaterial.ManufacturerId);
            return View(buildingMaterial);
        }

        // GET: BuildingMaterials/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var buildingMaterial = await _context.BuildingMaterials
                .Include(b => b.ContractorIdNavigation)
                .Include(b => b.ManufacturerIdNavigation)
                .SingleOrDefaultAsync(m => m.BuildingMaterialId == id);
            if (buildingMaterial == null)
            {
                return NotFound();
            }

            return View(buildingMaterial);
        }

        // POST: BuildingMaterials/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var buildingMaterial = await _context.BuildingMaterials.SingleOrDefaultAsync(m => m.BuildingMaterialId == id);
            _context.BuildingMaterials.Remove(buildingMaterial);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BuildingMaterialExists(int id)
        {
            return _context.BuildingMaterials.Any(e => e.BuildingMaterialId == id);
        }
    }
}

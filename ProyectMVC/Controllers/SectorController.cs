using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProyectMVC.Models;

namespace ProyectMVC.Controllers
{
    public class SectorController : Controller
    {
        private readonly ProyectMVCContext _context;

        public SectorController(ProyectMVCContext context)
        {
            _context = context;
        }

        // GET: Sector
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sector.ToListAsync());
        }

        // GET: Sector/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sectorModel = await _context.Sector
                .SingleOrDefaultAsync(m => m.Id == id);
            if (sectorModel == null)
            {
                return NotFound();
            }

            return View(sectorModel);
        }

        // GET: Sector/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sector/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre")] SectorModel sectorModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sectorModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sectorModel);
        }

        // GET: Sector/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sectorModel = await _context.Sector.SingleOrDefaultAsync(m => m.Id == id);
            if (sectorModel == null)
            {
                return NotFound();
            }
            return View(sectorModel);
        }

        // POST: Sector/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre")] SectorModel sectorModel)
        {
            if (id != sectorModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sectorModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SectorModelExists(sectorModel.Id))
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
            return View(sectorModel);
        }

        // GET: Sector/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sectorModel = await _context.Sector
                .SingleOrDefaultAsync(m => m.Id == id);
            if (sectorModel == null)
            {
                return NotFound();
            }

            return View(sectorModel);
        }

        // POST: Sector/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sectorModel = await _context.Sector.SingleOrDefaultAsync(m => m.Id == id);
            _context.Sector.Remove(sectorModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SectorModelExists(int id)
        {
            return _context.Sector.Any(e => e.Id == id);
        }
    }
}

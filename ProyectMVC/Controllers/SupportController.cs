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
    public class SupportController : Controller
    {
        private readonly ProyectMVCContext _context;

        public SupportController(ProyectMVCContext context)
        {
            _context = context;
        }

        // GET: Support
        public async Task<IActionResult> Index()
        {
            var proyectMVCContext = _context.SupportModel.Include(s => s.Cliente);
            return View(await proyectMVCContext.ToListAsync());
        }

        // GET: Support/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supportModel = await _context.SupportModel
                .Include(s => s.Cliente)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (supportModel == null)
            {
                return NotFound();
            }

            return View(supportModel);
        }

        // GET: Support/Create
        public IActionResult Create()
        {
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Nombre");
            return View();
        }

        // POST: Support/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Problema,Detalle,Estado,ClienteId")] SupportModel supportModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(supportModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Nombre", supportModel.ClienteId);
            return View(supportModel);
        }

        // GET: Support/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supportModel = await _context.SupportModel.SingleOrDefaultAsync(m => m.Id == id);
            if (supportModel == null)
            {
                return NotFound();
            }
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Nombre", supportModel.ClienteId);
            return View(supportModel);
        }

        // POST: Support/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Problema,Detalle,Estado,ClienteId")] SupportModel supportModel)
        {
            if (id != supportModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(supportModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupportModelExists(supportModel.Id))
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
            ViewData["ClienteId"] = new SelectList(_context.Cliente, "Id", "Nombre", supportModel.ClienteId);
            return View(supportModel);
        }

        // GET: Support/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var supportModel = await _context.SupportModel
                .Include(s => s.Cliente)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (supportModel == null)
            {
                return NotFound();
            }

            return View(supportModel);
        }

        // POST: Support/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var supportModel = await _context.SupportModel.SingleOrDefaultAsync(m => m.Id == id);
            _context.SupportModel.Remove(supportModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SupportModelExists(int id)
        {
            return _context.SupportModel.Any(e => e.Id == id);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EventosEF.Data;
using EventosEF.Models;

namespace EventosEF.Controllers
{
    public class LocalsController : Controller
    {
        private readonly Context _context;

        public LocalsController(Context context)
        {
            _context = context;
        }

        // GET: Locals
        public async Task<IActionResult> Index()
        {
            return View(await _context.Locais.ToListAsync());
        }

        // GET: Locals/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var local = await _context.Locais
                .FirstOrDefaultAsync(m => m.LocalId == id);
            if (local == null)
            {
                return NotFound();
            }

            return View(local);
        }

        // GET: Locals/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Locals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("LocalId,Nome,Endereco,Capacidade,Descricao")] Local local)
        {
            if (ModelState.IsValid)
            {
                local.LocalId = Guid.NewGuid();
                _context.Add(local);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(local);
        }

        // GET: Locals/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var local = await _context.Locais.FindAsync(id);
            if (local == null)
            {
                return NotFound();
            }
            return View(local);
        }

        // POST: Locals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("LocalId,Nome,Endereco,Capacidade,Descricao")] Local local)
        {
            if (id != local.LocalId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(local);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!LocalExists(local.LocalId))
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
            return View(local);
        }

        // GET: Locals/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var local = await _context.Locais
                .FirstOrDefaultAsync(m => m.LocalId == id);
            if (local == null)
            {
                return NotFound();
            }

            return View(local);
        }

        // POST: Locals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var local = await _context.Locais.FindAsync(id);
            if (local != null)
            {
                _context.Locais.Remove(local);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LocalExists(Guid id)
        {
            return _context.Locais.Any(e => e.LocalId == id);
        }
    }
}

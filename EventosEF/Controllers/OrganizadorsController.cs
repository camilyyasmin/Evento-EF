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
    public class OrganizadorsController : Controller
    {
        private readonly Context _context;

        public OrganizadorsController(Context context)
        {
            _context = context;
        }

        // GET: Organizadors
        public async Task<IActionResult> Index()
        {
            return View(await _context.Organizadores.ToListAsync());
        }

        // GET: Organizadors/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organizador = await _context.Organizadores
                .FirstOrDefaultAsync(m => m.OrganizadorId == id);
            if (organizador == null)
            {
                return NotFound();
            }

            return View(organizador);
        }

        // GET: Organizadors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Organizadors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OrganizadorId,Nome,Email,Telefone")] Organizador organizador)
        {
            if (ModelState.IsValid)
            {
                organizador.OrganizadorId = Guid.NewGuid();
                _context.Add(organizador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(organizador);
        }

        // GET: Organizadors/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organizador = await _context.Organizadores.FindAsync(id);
            if (organizador == null)
            {
                return NotFound();
            }
            return View(organizador);
        }

        // POST: Organizadors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("OrganizadorId,Nome,Email,Telefone")] Organizador organizador)
        {
            if (id != organizador.OrganizadorId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(organizador);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrganizadorExists(organizador.OrganizadorId))
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
            return View(organizador);
        }

        // GET: Organizadors/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var organizador = await _context.Organizadores
                .FirstOrDefaultAsync(m => m.OrganizadorId == id);
            if (organizador == null)
            {
                return NotFound();
            }

            return View(organizador);
        }

        // POST: Organizadors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var organizador = await _context.Organizadores.FindAsync(id);
            if (organizador != null)
            {
                _context.Organizadores.Remove(organizador);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OrganizadorExists(Guid id)
        {
            return _context.Organizadores.Any(e => e.OrganizadorId == id);
        }
    }
}

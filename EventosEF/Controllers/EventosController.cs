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
    public class EventosController : Controller
    {
        private readonly Context _context;

        public EventosController(Context context)
        {
            _context = context;
        }

        // GET: Eventos
        public async Task<IActionResult> Index()
        {
            var context = _context.Eventos.Include(e => e.Categoria).Include(e => e.Local).Include(e => e.Organizador);
            return View(await context.ToListAsync());
        }

        // GET: Eventos/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evento = await _context.Eventos
                .Include(e => e.Categoria)
                .Include(e => e.Local)
                .Include(e => e.Organizador)
                .FirstOrDefaultAsync(m => m.EventoId == id);
            if (evento == null)
            {
                return NotFound();
            }

            return View(evento);
        }

        // GET: Eventos/Create
        public IActionResult Create()
        {
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "Nome");
            ViewData["LocalId"] = new SelectList(_context.Locais, "LocalId", "Nome");
            ViewData["OrganizadorId"] = new SelectList(_context.Organizadores, "OrganizadorId", "Nome");
            return View();
        }

        // POST: Eventos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("EventoId,Nome,Data,LocalId,Descricao,CategoriaId,OrganizadorId")] Evento evento)
        {
            if (ModelState.IsValid)
            {
                evento.EventoId = Guid.NewGuid();
                _context.Add(evento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "Nome", evento.CategoriaId);
            ViewData["LocalId"] = new SelectList(_context.Locais, "LocalId", "Nome", evento.LocalId);
            ViewData["OrganizadorId"] = new SelectList(_context.Organizadores, "OrganizadorId", "Nome", evento.OrganizadorId);
            return View(evento);
        }

        // GET: Eventos/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evento = await _context.Eventos.FindAsync(id);
            if (evento == null)
            {
                return NotFound();
            }
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "Nome", evento.CategoriaId);
            ViewData["LocalId"] = new SelectList(_context.Locais, "LocalId", "Nome", evento.LocalId);
            ViewData["OrganizadorId"] = new SelectList(_context.Organizadores, "OrganizadorId", "Nome", evento.OrganizadorId);
            return View(evento);
        }

        // POST: Eventos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("EventoId,Nome,Data,LocalId,Descricao,CategoriaId,OrganizadorId")] Evento evento)
        {
            if (id != evento.EventoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(evento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EventoExists(evento.EventoId))
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
            ViewData["CategoriaId"] = new SelectList(_context.Categorias, "CategoriaId", "Nome", evento.CategoriaId);
            ViewData["LocalId"] = new SelectList(_context.Locais, "LocalId", "Nome", evento.LocalId);
            ViewData["OrganizadorId"] = new SelectList(_context.Organizadores, "OrganizadorId", "Nome", evento.OrganizadorId);
            return View(evento);
        }

        // GET: Eventos/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var evento = await _context.Eventos
                .Include(e => e.Categoria)
                .Include(e => e.Local)
                .Include(e => e.Organizador)
                .FirstOrDefaultAsync(m => m.EventoId == id);
            if (evento == null)
            {
                return NotFound();
            }

            return View(evento);
        }

        // POST: Eventos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var evento = await _context.Eventos.FindAsync(id);
            if (evento != null)
            {
                _context.Eventos.Remove(evento);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EventoExists(Guid id)
        {
            return _context.Eventos.Any(e => e.EventoId == id);
        }
    }
}

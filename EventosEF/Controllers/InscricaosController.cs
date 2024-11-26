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
    public class InscricaosController : Controller
    {
        private readonly Context _context;

        public InscricaosController(Context context)
        {
            _context = context;
        }

        // GET: Inscricaos
        public async Task<IActionResult> Index()
        {
            var context = _context.Inscricaos.Include(i => i.Evento).Include(i => i.Participantes);
            return View(await context.ToListAsync());
        }

        // GET: Inscricaos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inscricao = await _context.Inscricaos
                .Include(i => i.Evento)
                .Include(i => i.Participantes)
                .FirstOrDefaultAsync(m => m.InscricaoId == id);
            if (inscricao == null)
            {
                return NotFound();
            }

            return View(inscricao);
        }

        // GET: Inscricaos/Create
        public IActionResult Create()
        {
            ViewData["EventoId"] = new SelectList(_context.Eventos, "EventoId", "Nome");
            ViewData["ParticipanteId"] = new SelectList(_context.Participantes, "ParticipanteId", "Nome");
            return View();
        }

        // POST: Inscricaos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("InscricaoId,DataInscricao,EventoId,ParticipanteId")] Inscricao inscricao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inscricao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EventoId"] = new SelectList(_context.Eventos, "EventoId", "Nome", inscricao.EventoId);
            ViewData["ParticipanteId"] = new SelectList(_context.Participantes, "ParticipanteId", "Nome", inscricao.ParticipanteId);
            return View(inscricao);
        }

        // GET: Inscricaos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inscricao = await _context.Inscricaos.FindAsync(id);
            if (inscricao == null)
            {
                return NotFound();
            }
            ViewData["EventoId"] = new SelectList(_context.Eventos, "EventoId", "Nome", inscricao.EventoId);
            ViewData["ParticipanteId"] = new SelectList(_context.Participantes, "ParticipanteId", "Nome", inscricao.ParticipanteId);
            return View(inscricao);
        }

        // POST: Inscricaos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("InscricaoId,DataInscricao,EventoId,ParticipanteId")] Inscricao inscricao)
        {
            if (id != inscricao.InscricaoId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inscricao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InscricaoExists(inscricao.InscricaoId))
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
            ViewData["EventoId"] = new SelectList(_context.Eventos, "EventoId", "Nome", inscricao.EventoId);
            ViewData["ParticipanteId"] = new SelectList(_context.Participantes, "ParticipanteId", "Nome", inscricao.ParticipanteId);
            return View(inscricao);
        }

        // GET: Inscricaos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inscricao = await _context.Inscricaos
                .Include(i => i.Evento)
                .Include(i => i.Participantes)
                .FirstOrDefaultAsync(m => m.InscricaoId == id);
            if (inscricao == null)
            {
                return NotFound();
            }

            return View(inscricao);
        }

        // POST: Inscricaos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inscricao = await _context.Inscricaos.FindAsync(id);
            if (inscricao != null)
            {
                _context.Inscricaos.Remove(inscricao);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InscricaoExists(int id)
        {
            return _context.Inscricaos.Any(e => e.InscricaoId == id);
        }
    }
}

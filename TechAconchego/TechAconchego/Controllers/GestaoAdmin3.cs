using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TechAconchego.Data;
using TechAconchego.Models;

namespace TechAconchego.Controllers
{
    public class GestaoAdmin3 : Controller
    {
        private readonly ApplicationDbContext _context;

        public GestaoAdmin3(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GestaoAdmin3
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Alugueres.Include(a => a.Alojamento).Include(a => a.Utilizador);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: GestaoAdmin3/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluguer = await _context.Alugueres
                .Include(a => a.Alojamento)
                .Include(a => a.Utilizador)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aluguer == null)
            {
                return NotFound();
            }

            return View(aluguer);
        }

        // GET: GestaoAdmin3/Create
        public IActionResult Create()
        {
            ViewData["AlojamentoId"] = new SelectList(_context.Alojamentos, "Id", "Id");
            ViewData["UtilizadorId"] = new SelectList(_context.Utilizadores, "Id", "Email");
            return View();
        }

        // POST: GestaoAdmin3/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nome,Prazo,UtilizadorId,AlojamentoId,Estado")] Aluguer aluguer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(aluguer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AlojamentoId"] = new SelectList(_context.Alojamentos, "Id", "Id", aluguer.AlojamentoId);
            ViewData["UtilizadorId"] = new SelectList(_context.Utilizadores, "Id", "Email", aluguer.UtilizadorId);
            return View(aluguer);
        }

        // GET: GestaoAdmin3/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluguer = await _context.Alugueres.FindAsync(id);
            if (aluguer == null)
            {
                return NotFound();
            }
            ViewData["AlojamentoId"] = new SelectList(_context.Alojamentos, "Id", "Id", aluguer.AlojamentoId);
            ViewData["UtilizadorId"] = new SelectList(_context.Utilizadores, "Id", "Email", aluguer.UtilizadorId);
            return View(aluguer);
        }

        // POST: GestaoAdmin3/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nome,Prazo,UtilizadorId,AlojamentoId,Estado")] Aluguer aluguer)
        {
            if (id != aluguer.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(aluguer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AluguerExists(aluguer.Id))
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
            ViewData["AlojamentoId"] = new SelectList(_context.Alojamentos, "Id", "Id", aluguer.AlojamentoId);
            ViewData["UtilizadorId"] = new SelectList(_context.Utilizadores, "Id", "Email", aluguer.UtilizadorId);
            return View(aluguer);
        }

        // GET: GestaoAdmin3/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var aluguer = await _context.Alugueres
                .Include(a => a.Alojamento)
                .Include(a => a.Utilizador)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (aluguer == null)
            {
                return NotFound();
            }

            return View(aluguer);
        }

        // POST: GestaoAdmin3/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var aluguer = await _context.Alugueres.FindAsync(id);
            if (aluguer != null)
            {
                _context.Alugueres.Remove(aluguer);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AluguerExists(int id)
        {
            return _context.Alugueres.Any(e => e.Id == id);
        }
    }
}

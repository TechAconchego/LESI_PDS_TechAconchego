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
    public class GestaoAdmin4 : Controller
    {
        private readonly ApplicationDbContext _context;

        public GestaoAdmin4(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: GestaoAdmin4
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Manutencoes.Include(m => m.Alojamento);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: GestaoAdmin4/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manutencao = await _context.Manutencoes
                .Include(m => m.Alojamento)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (manutencao == null)
            {
                return NotFound();
            }

            return View(manutencao);
        }

        // GET: GestaoAdmin4/Create
        public IActionResult Create()
        {
            ViewData["AlojamentoId"] = new SelectList(_context.Alojamentos, "Id", "Id");
            return View();
        }

        // POST: GestaoAdmin4/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DescricaoProblema,Estado,Prestador,AlojamentoId")] Manutencao manutencao)
        {
            if (ModelState.IsValid)
            {
                _context.Add(manutencao);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AlojamentoId"] = new SelectList(_context.Alojamentos, "Id", "Id", manutencao.AlojamentoId);
            return View(manutencao);
        }

        // GET: GestaoAdmin4/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manutencao = await _context.Manutencoes.FindAsync(id);
            if (manutencao == null)
            {
                return NotFound();
            }
            ViewData["AlojamentoId"] = new SelectList(_context.Alojamentos, "Id", "Id", manutencao.AlojamentoId);
            return View(manutencao);
        }

        // POST: GestaoAdmin4/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DescricaoProblema,Estado,Prestador,AlojamentoId")] Manutencao manutencao)
        {
            if (id != manutencao.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(manutencao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ManutencaoExists(manutencao.Id))
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
            ViewData["AlojamentoId"] = new SelectList(_context.Alojamentos, "Id", "Id", manutencao.AlojamentoId);
            return View(manutencao);
        }

        // GET: GestaoAdmin4/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var manutencao = await _context.Manutencoes
                .Include(m => m.Alojamento)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (manutencao == null)
            {
                return NotFound();
            }

            return View(manutencao);
        }

        // POST: GestaoAdmin4/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var manutencao = await _context.Manutencoes.FindAsync(id);
            if (manutencao != null)
            {
                _context.Manutencoes.Remove(manutencao);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ManutencaoExists(int id)
        {
            return _context.Manutencoes.Any(e => e.Id == id);
        }
    }
}

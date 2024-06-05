using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TechAconchego.Data;
using TechAconchego.Models;

namespace TechAconchego.Controllers
{
    public class GerirAlojE : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<GerirAlojE> _logger;

        public GerirAlojE(ApplicationDbContext context, ILogger<GerirAlojE> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: GerirAlojE
        public async Task<IActionResult> Index()
        {
            return View(await _context.Alojamentos.ToListAsync());
        }

        // GET: GerirAlojE/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alojamento = await _context.Alojamentos.FirstOrDefaultAsync(m => m.Id == id);
            if (alojamento == null)
            {
                return NotFound();
            }

            return View(alojamento);
        }

        // GET: GerirAlojE/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GerirAlojE/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Localizacao,Preco,Estado,Descricao,ImagemUrl")] Alojamento alojamento)
        {
            _logger.LogInformation("Create method called for Alojamento");

            ModelState.Remove("Alugueres");
            ModelState.Remove("Manutencoes");
            ModelState.Remove("RelatorioProblemas");

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Add(alojamento);
                    await _context.SaveChangesAsync();
                    _logger.LogInformation("New accommodation created with ID: {Id}", alojamento.Id);
                    TempData["SuccessMessage"] = "Alojamento criado com sucesso.";

                    // Retorna para a página anterior
                    string returnUrl = Request.Headers["Referer"].ToString();
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        // Se não houver URL de referência, redireciona para uma rota padrão
                        return RedirectToAction(nameof(Index));
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error occurred while creating Alojamento");
                    TempData["ErrorMessage"] = "Ocorreu um erro ao criar o alojamento. Por favor, tente novamente.";
                }
            }
            else
            {
                _logger.LogWarning("ModelState is not valid");
            }

            return View(alojamento);
        }

        // GET: GerirAlojE/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alojamento = await _context.Alojamentos.FindAsync(id);
            if (alojamento == null)
            {
                return NotFound();
            }
            return View(alojamento);
        }

        // POST: GerirAlojE/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Localizacao,Preco,Estado,Descricao,ImagemUrl")] Alojamento alojamento)
        {
            _logger.LogInformation("Edit method called with ID = {Id}", id);

            if (id != alojamento.Id)
            {
                _logger.LogWarning("ID mismatch: route ID = {RouteId}, model ID = {ModelId}", id, alojamento.Id);
                return NotFound();
            }

            ModelState.Remove("Alugueres");
            ModelState.Remove("Manutencoes");
            ModelState.Remove("RelatorioProblemas");

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(alojamento);
                    await _context.SaveChangesAsync();

                    TempData["SuccessMessage"] = "Alojamento atualizado com sucesso!";
                    _logger.LogInformation("Alojamento with ID = {Id} updated successfully", id);

                    // Retorna para a página anterior
                    string returnUrl = Request.Headers["Referer"].ToString();
                    if (!string.IsNullOrEmpty(returnUrl))
                    {
                        return Redirect(returnUrl);
                    }
                    else
                    {
                        // Se não houver URL de referência, redireciona para uma rota padrão
                        return RedirectToAction(nameof(Index));
                    }
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    _logger.LogError(ex, "Concurrency error occurred while updating Alojamento with ID = {Id}", alojamento.Id);
                    TempData["ErrorMessage"] = "A concurrency error occurred. Please try again.";
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error occurred while updating Alojamento with ID = {Id}", alojamento.Id);
                    TempData["ErrorMessage"] = "An error occurred while updating the Alojamento. Please try again.";
                }
            }

            return View(alojamento);
        }

        // GET: GerirAlojE/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var alojamento = await _context.Alojamentos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (alojamento == null)
            {
                return NotFound();
            }

            return View(alojamento);
        }

        // POST: GerirAlojE/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var alojamento = await _context.Alojamentos.FindAsync(id);
            if (alojamento != null)
            {
                _context.Alojamentos.Remove(alojamento);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}

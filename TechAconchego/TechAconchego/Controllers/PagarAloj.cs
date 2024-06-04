using Microsoft.AspNetCore.Mvc;
using TechAconchego.Data;
using TechAconchego.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using System.Linq;

namespace TechAconchego.Controllers
{
    public class PagarAloj : Controller
    {
        private readonly ApplicationDbContext _context;

        public PagarAloj(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Verificar se existe um estudante na sessão
            var estudanteId = HttpContext.Session.GetInt32("EstudanteId");
            if (!estudanteId.HasValue)
            {
                // Redirecionar para a página de erro
                return RedirectToAction("SemAluguer", "Erro");
            }

            // Obter o aluguer do estudante
            var aluguer = _context.Alugueres
                .Include(a => a.Alojamento)
                .FirstOrDefault(a => a.UtilizadorId == estudanteId.Value);

            if (aluguer == null)
            {
                // Redirecionar para a página de erro se não houver aluguer associado ao estudante
                return RedirectToAction("SemAluguer", "Erro");
            }

            return View(aluguer);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechAconchego.Data;
using TechAconchego.Models;

namespace TechAconchego.Controllers
{
    public class GerirConta : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<GerirConta> _logger;

        public GerirConta(ApplicationDbContext context, ILogger<GerirConta> logger)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("Index method called");

            var nome = HttpContext.Session.GetString("NomeUtilizador");
            if (string.IsNullOrEmpty(nome))
            {
                _logger.LogWarning("NomeUtilizador is null or empty");
                return RedirectToAction("Login", "Account");
            }

            var user = _context.Utilizadores
                .Include(u => u.Alugueres)
                .ThenInclude(a => a.Alojamento)
                .FirstOrDefault(u => u.NomeUtilizador == nome);

            if (user == null)
            {
                _logger.LogWarning("User not found for nome: {Nome}", nome);
                return NotFound();
            }

            return View(user);
        }

        public IActionResult Detalhes(int id)
        {
            var alojamento = _context.Alojamentos.FirstOrDefault(a => a.Id == id);
            if (alojamento == null)
            {
                return NotFound();
            }
            return View("~/Views/Detalhes/Index.cshtml", alojamento); // Use the correct path to the view
        }

        public IActionResult EditarPerfil()
        {
            // Lógica para editar o perfil do usuário
            return View();
        }

        public IActionResult EncerrarSessao()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }

        public IActionResult CancelarAluguer(int aluguerId)
        {
            var aluguer = _context.Alugueres.FirstOrDefault(a => a.Id == aluguerId);
            if (aluguer != null)
            {
                var alojamento = _context.Alojamentos.FirstOrDefault(a => a.Id == aluguer.AlojamentoId);
                if (alojamento != null)
                {
                    alojamento.Estado = "Disponível";
                }

                _context.Alugueres.Remove(aluguer);
                _context.SaveChanges();
            }

            return RedirectToAction("Index", "GerirConta");
        }
    }
}


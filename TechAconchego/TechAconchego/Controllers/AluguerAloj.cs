using Microsoft.AspNetCore.Mvc;
using TechAconchego.Data;
using TechAconchego.Models;
using TechAconchego.Helpers;

namespace TechAconchego.Controllers
{
    public class AluguerAloj : Controller
    {
        private readonly ApplicationDbContext _context;

        public AluguerAloj(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            // Obter alojamentos disponíveis
            var alojamentosDisponiveis = _context.Alojamentos
                                                 .Where(a => a.Estado != "Reservado")
                                                 .ToList();

            // Obter o ID do estudante logado (vamos assumir que está armazenado na sessão)
            var estudanteId = HttpContext.Session.GetInt32("EstudanteId");
            var estudanteTemAluguer = estudanteId.HasValue && _context.Alugueres.Any(a => a.UtilizadorId == estudanteId.Value);

            // Passar dados para a view
            ViewBag.EstudanteTemAluguer = estudanteTemAluguer;
            ViewBag.AlojamentosDisponiveis = alojamentosDisponiveis;

            HttpContext.Session.SetBool("EstudanteTemAluguer", estudanteTemAluguer);

            return View();
        }

        [HttpPost]
        public IActionResult Reservar(int alojamentoId)
        {
            var estudanteId = HttpContext.Session.GetInt32("EstudanteId");
            if (estudanteId.HasValue)
            {
                // Verifica se o estudante já possui um aluguer
                var estudanteTemAluguer = _context.Alugueres.Any(a => a.UtilizadorId == estudanteId.Value);
                if (!estudanteTemAluguer)
                {
                    // Cria um novo aluguel
                    var novoAluguer = new Aluguer
                    {
                        Nome = "Aluguer " + DateTime.Now.ToString(),
                        Prazo = DateTime.Now.AddMonths(1),
                        UtilizadorId = estudanteId.Value,
                        AlojamentoId = alojamentoId,
                        Estado = "Reservado"
                    };

                    _context.Alugueres.Add(novoAluguer);

                    // Atualiza o estado do alojamento
                    var alojamento = _context.Alojamentos.Find(alojamentoId);
                    if (alojamento != null)
                    {
                        alojamento.Estado = "Reservado";
                    }

                    _context.SaveChanges();
                }
            }

            return RedirectToAction("Index");
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
    }
}

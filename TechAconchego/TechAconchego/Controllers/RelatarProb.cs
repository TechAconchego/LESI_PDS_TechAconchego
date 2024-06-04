using Microsoft.AspNetCore.Mvc;

namespace TechAconchego.Controllers
{
    public class RelatarProb : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}



//using Microsoft.AspNetCore.Mvc;
//using TechAconchego.Data;
//using TechAconchego.Models;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Linq;

//namespace TechAconchego.Controllers
//{
//    public class RelatarProbController : Controller
//    {
//        private readonly ApplicationDbContext _context;

//        public RelatarProbController(ApplicationDbContext context)
//        {
//            _context = context;
//        }

//        // GET: RelatarProb/Index
//        public IActionResult Index()
//        {
//            // Obter o nome do utilizador da sessão atual
//            var nomeUtilizador = HttpContext.Session.GetString("NomeUtilizador");

//            if (string.IsNullOrEmpty(nomeUtilizador))
//            {
//                // Redirecionar para a página de login se o utilizador não estiver autenticado
//                return RedirectToAction("Index", "Login");
//            }

//            // Obter informações do utilizador e do alojamento reservado
//            var utilizador = _context.Utilizadores
//                .Include(u => u.Alugueres)
//                .ThenInclude(a => a.Alojamento)
//                .FirstOrDefault(u => u.NomeUtilizador == nomeUtilizador);

//            if (utilizador == null)
//            {
//                // Retornar uma visualização de erro se o utilizador não for encontrado
//                return View("Error");
//            }

//            // Criar uma lista de tipos de problema
//            var tiposProblema = new List<string> { "Alojamento", "Pagamento", "Outro" };

//            // Passar o utilizador e os tipos de problema para a view
//            ViewData["TiposProblema"] = tiposProblema;
//            return View(utilizador);
//        }

//        // POST: RelatarProb/Report
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public IActionResult Report(RelatorioProblema relatorio)
//        {
//            if (ModelState.IsValid)
//            {
//                // Define a data de registro como a data atual
//                relatorio.DataRegistro = DateTime.Now;

//                // Adiciona o relatório de problema ao contexto e salva as mudanças no banco de dados
//                _context.RelatorioProblemas.Add(relatorio);
//                _context.SaveChanges();

//                // Redireciona para a página de sucesso ou outra página desejada
//                return RedirectToAction(nameof(Success));
//            }

//            // Se o modelo não for válido, retorna para a mesma view com os erros de validação
//            var tiposProblema = new List<string> { "Alojamento", "Pagamento", "Outro" };
//            ViewData["TiposProblema"] = tiposProblema;
//            return View(nameof(Index), relatorio);
//        }

//        // GET: RelatarProb/Success
//        public IActionResult Success()
//        {
//            // Aqui você pode mostrar uma página de sucesso após relatar o problema
//            return View();
//        }
//    }
//}



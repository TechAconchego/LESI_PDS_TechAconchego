using Microsoft.AspNetCore.Mvc;
using TechAconchego.Data;

namespace TechAconchego.Controllers
{
    public class PesquisaAlojDisp : Controller
    {
        private readonly ApplicationDbContext _context;

        public PesquisaAlojDisp(ApplicationDbContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult Index(string localizacao, decimal? precoMax)
        {
            var alojamentos = _context.Alojamentos.AsQueryable();

            // Aplica os filtros de pesquisa, se existirem
            if (!string.IsNullOrEmpty(localizacao))
            {
                alojamentos = alojamentos.Where(a => a.Localizacao.Contains(localizacao));
            }

            if (precoMax.HasValue)
            {
                float precoMaxFloat = (float)(precoMax ?? 0);
                alojamentos = alojamentos.Where(a => a.Preco <= precoMaxFloat);
            }

            return View(alojamentos.ToList());
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

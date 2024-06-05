using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using TechAconchego.Data;
using TechAconchego.Models;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace TechAconchego.Controllers
{
    public class GestaoAdmin1 : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<GestaoAdmin1> _logger;

        public GestaoAdmin1(ApplicationDbContext context, ILogger<GestaoAdmin1> logger)
        {
            _context = context;
            _logger = logger;
        }

        // GET: GestaoAdmin1
        public async Task<IActionResult> Index()
        {
            return View(await _context.Utilizadores.ToListAsync());
        }

        // GET: GestaoAdmin1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utilizador = await _context.Utilizadores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (utilizador == null)
            {
                return NotFound();
            }

            return View(utilizador);
        }

        //GET: GestaoAdmin1/Create
        public IActionResult Create()
        {
            // Passar as opções de roles para a View
            ViewBag.RoleOptions = new List<SelectListItem>
            {
                new SelectListItem { Value = "Admin", Text = "Admin" },
                new SelectListItem { Value = "Estudante", Text = "Estudante" },
                new SelectListItem { Value = "Senhorio", Text = "Senhorio" },
                new SelectListItem { Value = "Manutencao", Text = "Manutenção" }
            };

            return View();
        }


        // POST: GestaoAdmin1/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NomeUtilizador,Email,Password,Role")] Utilizador utilizador)
        {
            _logger.LogInformation("Create method called");

            ModelState.Remove("Alugueres");  // Ignora a validação para o campo Alugueres
            ModelState.Remove("RelatorioProblemas");

            if (ModelState.IsValid)
            {
                _logger.LogInformation("ModelState is valid");

                _context.Add(utilizador);
                await _context.SaveChangesAsync();

                _logger.LogInformation("New user created with ID: {Id}", utilizador.Id);

                // Log temporário para verificar o nome do utilizador
                _logger.LogInformation("Nome do utilizador: {NomeUtilizador}", utilizador.NomeUtilizador);

                //return RedirectToAction(nameof(Index));


                // Adicione uma mensagem de sucesso à TempData
                TempData["SuccessMessage"] = "Utilizador criado com sucesso.";

                // Verifica se a URL de referência está presente nos cabeçalhos da solicitação
                string returnUrl = Request.Headers["Referer"].ToString();
                if (!string.IsNullOrEmpty(returnUrl))
                {
                    // Redireciona para a URL de referência
                    return Redirect(returnUrl);
                }
                else
                {
                    // Se a URL de referência não estiver presente, redireciona para uma rota padrão
                    return RedirectToAction(nameof(Index));
                }
            }
            else
            {
                _logger.LogWarning("ModelState is not valid");
                foreach (var entry in ModelState)
                {
                    foreach (var error in entry.Value.Errors)
                    {
                        _logger.LogWarning($"Error in property {entry.Key}: {error.ErrorMessage}");
                    }
                }

                // Se houver erros de validação, retorne a view de criação de usuário para exibir os erros
                return View(utilizador);
            }

            // Repassar as opções de roles para a View em caso de erro de validação
            ViewBag.RoleOptions = new List<SelectListItem>
            {
                new SelectListItem { Value = "Admin", Text = "Admin" },
                new SelectListItem { Value = "Estudante", Text = "Estudante" },
                new SelectListItem { Value = "Senhorio", Text = "Senhorio" },
                new SelectListItem { Value = "Manutencao", Text = "Manutenção" }
            };

            return View(utilizador);
        }

        // GET: GestaoAdmin1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utilizador = await _context.Utilizadores.FindAsync(id);
            if (utilizador == null)
            {
                return NotFound();
            }
            return View(utilizador);
        }

        // POST: GestaoAdmin1/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,NomeUtilizador,Email,Password,Role")] Utilizador utilizador)
        {
            if (id != utilizador.Id)
            {
                return NotFound();
            }

            // Remove from ModelState validation if it causes issues
            ModelState.Remove("Alugueres");
            ModelState.Remove("RelatorioProblemas");

            if (ModelState.IsValid)
            {
                try
                {
                    var existingUser = await _context.Utilizadores.AsNoTracking().FirstOrDefaultAsync(u => u.Id == id);
                    if (existingUser == null)
                    {
                        return NotFound();
                    }

                    // Retain the current password if no new password is provided
                    if (string.IsNullOrEmpty(utilizador.Password))
                    {
                        utilizador.Password = existingUser.Password;
                    }

                    _context.Update(utilizador);
                    await _context.SaveChangesAsync();


                    // Adicionar um script JavaScript à ViewBag para redirecionar duas páginas atrás
                    ViewBag.RedirectBack = true;

                    TempData["SuccessMessage"] = "Utilizador atualizado com sucesso!";
                    return RedirectToAction("Index", "Home");
                }
                catch (DbUpdateConcurrencyException ex)
                {
                    if (!UtilizadorExists(utilizador.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        _logger.LogError(ex, "Concurrency error occurred while updating user with ID: {Id}", utilizador.Id);
                        TempData["ErrorMessage"] = "A concurrency error occurred. Please try again.";
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "An error occurred while updating user with ID: {Id}", utilizador.Id);
                    TempData["ErrorMessage"] = "An error occurred while updating the user. Please try again.";
                    // Se ocorrer um erro, retorne um JSON indicando o erro
                    return Json(new { success = false, error = ex.Message });
                }
            }
            else
            {
                // Log detailed information about invalid ModelState
                _logger.LogWarning("ModelState is not valid");
                foreach (var entry in ModelState)
                {
                    foreach (var error in entry.Value.Errors)
                    {
                        _logger.LogWarning($"Error in property {entry.Key}: {error.ErrorMessage}");
                    }
                }
                TempData["ErrorMessage"] = "Invalid data. Please correct the errors and try again.";
            }
            return View(utilizador);
        }



        // GET: GestaoAdmin1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var utilizador = await _context.Utilizadores
                .FirstOrDefaultAsync(m => m.Id == id);
            if (utilizador == null)
            {
                return NotFound();
            }

            return View(utilizador);
        }

        // POST: GestaoAdmin1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var utilizador = await _context.Utilizadores.FindAsync(id);
            if (utilizador != null)
            {
                _context.Utilizadores.Remove(utilizador);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UtilizadorExists(int id)
        {
            return _context.Utilizadores.Any(e => e.Id == id);
        }
    }
}

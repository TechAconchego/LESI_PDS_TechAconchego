using Microsoft.AspNetCore.Mvc;
using TechAconchego.Models;
using TechAconchego.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using TechAconchego.Helpers;

namespace TechAconchego.Controllers
{
    public class Login : Controller
    {

        string nomeUtilizador;
        string password;

        private readonly ApplicationDbContext db;

        public Login(ApplicationDbContext context)
        {
            db = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(Utilizador model)
        {
            Console.WriteLine("Login method called");

            ModelState.Remove("Email");
            ModelState.Remove("Role");
            ModelState.Remove("Alugueres");
            ModelState.Remove("RelatorioProblemas");


            if (ModelState.IsValid)
            {
                Console.WriteLine("Model is valid");

                var user = db.Utilizadores.FirstOrDefault(u => u.NomeUtilizador == model.NomeUtilizador && u.Password == model.Password);

                if (user != null)
                {
                    Console.WriteLine("User found");

                    HttpContext.Session.SetString("NomeUtilizador", model.NomeUtilizador);
                    HttpContext.Session.SetString("UserRole", user.Role);

                    // Set the EstudanteId in the session
                    HttpContext.Session.SetInt32("EstudanteId", user.Id);


                    var estudanteTemAluguer = db.Alugueres.Any(a => a.UtilizadorId == user.Id);
                    HttpContext.Session.SetBool("EstudanteTemAluguer", estudanteTemAluguer);


                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    Console.WriteLine("User not found");

                    ModelState.AddModelError("", "Invalid login attempt.");
                    return View(model);
                }
            }

            Console.WriteLine("Model is not valid");
            foreach (var entry in ModelState)
            {
                foreach (var error in entry.Value.Errors)
                {
                    Console.WriteLine($"Error in property {entry.Key}: {error.ErrorMessage}");
                }
            }

            return View(model);
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Home");
        }
    }
}

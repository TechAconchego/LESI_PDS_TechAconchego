using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using TechAconchego.Models;

namespace TechAconchego.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Alojamento> Alojamentos { get; set; }
        public DbSet<Aluguer> Alugueres { get; set; }
        public DbSet<Utilizador> Utilizadores { get; set; }
        public DbSet<Manutencao> Manutencoes { get; set; }
        public DbSet<RelatorioProblema> RelatorioProblemas { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //}
    }
}

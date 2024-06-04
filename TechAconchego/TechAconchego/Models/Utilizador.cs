using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TechAconchego.Models
{
    public class Utilizador
    {
        public int Id { get; set; }
        [Required]
        public string NomeUtilizador { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        public string Role { get; set; }


        public virtual ICollection<Aluguer> Alugueres { get; set; }
        public virtual ICollection<RelatorioProblema> RelatorioProblemas { get; set; }


    }
}

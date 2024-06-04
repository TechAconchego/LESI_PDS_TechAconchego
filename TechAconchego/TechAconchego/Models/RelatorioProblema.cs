using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TechAconchego.Models
{
    public class RelatorioProblema
    {

        public int Id { get; set; }

        [Required]
        public string Tipo { get; set; }

        [Required]
        public string Descricao { get; set; }

        public DateTime DataRegistro { get; set; }




        [ForeignKey("Alojamento")]
        public int AlojamentoId { get; set; }
        public Alojamento Alojamento { get; set; }

        [ForeignKey("Utilizador")]
        public int UtilizadorId { get; set; }
        public Utilizador Utilizador { get; set; }
    }
}

using System.ComponentModel.DataAnnotations.Schema;

namespace TechAconchego.Models
{
    public class Aluguer
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime Prazo { get; set; }


        [ForeignKey("UtilizadorId")]
        public int UtilizadorId { get; set; }
        public Utilizador Utilizador { get; set; }

        [ForeignKey("AlojamentoId")]
        public int AlojamentoId { get; set; }
        public Alojamento Alojamento { get; set; }

        [ForeignKey("Estado")]
        public string Estado { get; set; }
    }
}

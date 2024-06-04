using System.ComponentModel.DataAnnotations.Schema;

namespace TechAconchego.Models
{
    public class Manutencao
    {

        public int Id { get; set; }
        
        public string DescricaoProblema { get; set; }
        public string Estado { get; set; }
        public string Prestador { get; set; }


        [ForeignKey("Alojamento")]
        public int AlojamentoId { get; set; }
        public Alojamento Alojamento { get; set; }


    }


}

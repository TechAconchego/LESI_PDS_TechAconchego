using System.ComponentModel.DataAnnotations.Schema;

namespace TechAconchego.Models
{
    public class Alojamento
    {

        public int Id { get; set; }
        public string Localizacao { get; set; }
        public float Preco { get; set; }
        public string Estado { get; set; }
        public  string Descricao { get; set; }
        public string ImagemUrl { get; set; }


        public virtual ICollection<Aluguer> Alugueres { get; set; }
        public virtual ICollection<Manutencao> Manutencoes { get; set; }

        public virtual ICollection<RelatorioProblema> RelatorioProblemas { get; set; }


    }
}

using System.ComponentModel.DataAnnotations;

namespace EventosEF.Models
{
    public class Local
    {
        [Display(Name = "Local")]
        public Guid LocalId { get; set; }

        public string Nome { get; set; }

        [Display(Name = "Endereço")]
        public string Endereco { get; set; }

        public int Capacidade { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        public ICollection<Evento>? Eventos { get; set; }
    }
}

using System.ComponentModel.DataAnnotations;

namespace EventosEF.Models
{
    public class Evento
    {
        [Display(Name = "Evento")]
        public Guid EventoId { get; set; }

        public string Nome { get; set; }

        public DateTime Data { get; set; }

        [Display(Name = "Descrição")]
        public string Descricao { get; set; }

        public ICollection<Inscricao>? Inscricaos { get; set; }

        [Display(Name = "Categoria")]
        public Guid CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }
        [Display(Name = "Local")]
        public Guid LocalId { get; set; }
        public Local? Local { get; set; }
        [Display(Name = "Organizador")]
        public Guid OrganizadorId { get; set; }
        public Organizador? Organizador { get; set; }
    }
}

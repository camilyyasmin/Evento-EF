using System.ComponentModel.DataAnnotations;

namespace EventosEF.Models
{
    public class Inscricao
    {
        [Display(Name = "Inscrção")]
        public int InscricaoId { get; set; }

        [Display(Name = "Data da Inscrição")]
        public DateTime DataInscricao { get; set; }

        [Display(Name = "Evento")]
        public Guid EventoId { get; set; }

        [Display(Name = "Participante")]
        public Guid ParticipanteId { get; set; }

        public Evento? Evento { get; set; }

        public Participante? Participantes { get; set; }
    }
}

namespace EventosEF.Models
{
    public class Participante
    {
        public Guid ParticipanteId { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }

        public ICollection<Inscricao>? Inscricaos { get; set; }
    }
}

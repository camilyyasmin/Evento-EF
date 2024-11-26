namespace EventosEF.Models
{
    public class Organizador
    {
        public Guid OrganizadorId { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }

        public ICollection<Evento>? Eventos { get; set; }
    }
}

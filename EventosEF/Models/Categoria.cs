namespace EventosEF.Models
{
    public class Categoria
    {
        public Guid CategoriaId { get; set; }

        public string Nome { get; set; }

        public ICollection<Evento>? Eventos  { get; set; }
    }
}

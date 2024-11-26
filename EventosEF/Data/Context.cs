using EventosEF.Models;
using Microsoft.EntityFrameworkCore;

namespace EventosEF.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options){ }

        public DbSet<Evento> Eventos { get; set; }
        public DbSet<Local> Locais { get; set; }

        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Organizador> Organizadores { get; set; }

        public DbSet<Participante> Participantes { get; set; }

        public DbSet<Inscricao> Inscricaos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Evento>().ToTable("tbEventos");
            modelBuilder.Entity<Local>().ToTable("tbLocais");
            modelBuilder.Entity<Categoria>().ToTable("tbCategorias");
            modelBuilder.Entity<Organizador>().ToTable("tbOrganizadores");
            modelBuilder.Entity<Participante>().ToTable("tbParticipantes");
            modelBuilder.Entity<Inscricao>().ToTable("tbInscricaos");
        }

    }
}

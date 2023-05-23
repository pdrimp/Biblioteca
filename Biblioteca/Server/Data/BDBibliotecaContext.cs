using Biblioteca.Shared.Modelos;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Server.Data
{
    public class BDBibliotecaContext : DbContext
    {
        public BDBibliotecaContext(DbContextOptions<BDBibliotecaContext> options) : base(options)
        {
        }
        public DbSet<Libro> Libros { get; set; }
        public DbSet<Editorial> Editoriales { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Autor> Autores { get; set; }
        public DbSet<Prestamo> Prestamos { get; set; }
    }
}

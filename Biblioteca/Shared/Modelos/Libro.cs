using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Shared.Modelos
{
    public class Libro
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Título es obligatorio")]
        public string? Titulo { get; set; }
        public DateTime Fecha_publicacion { get; set; }

        public int EditorialId { get; set; }
        public virtual Editorial? Editorial { get; set; }
        public virtual ICollection<Autor>? Autores { get; set; }
        public virtual ICollection<Prestamo>? Prestamos { get; set; }
    }
}

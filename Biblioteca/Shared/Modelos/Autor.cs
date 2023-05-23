using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Shared.Modelos
{
    public class Autor
    {
        public int Id { get; set; }
        [Required]
        public string? Nombre { get; set; }
        [Required]
        public string? Correo { get; set; }

        public virtual ICollection<Libro>? Libros { get; set; }
    }
}

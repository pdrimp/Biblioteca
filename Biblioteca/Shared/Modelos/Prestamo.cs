using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Shared.Modelos
{
    public class Prestamo
    {
        public int Id { get; set; }
        public DateTime Fecha_prestamo { get; set; }
        public DateTime? Fecha_entrega { get; set; }

        public int UsuarioId { get; set; }
        public virtual Usuario? Usuario { get; set; }
        public int LibroId { get; set; }
        public virtual Libro? Libro { get; set; }
    }
}

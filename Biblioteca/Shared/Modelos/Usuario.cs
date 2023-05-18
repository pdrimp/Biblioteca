using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Shared.Modelos
{
    public class Usuario
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="El nombre es obligatorio")]
        public string? Nombre { get; set; }
        [Required(ErrorMessage = "El correo es obligatorio")]
        public string? Correo { get; set; }
    }
}

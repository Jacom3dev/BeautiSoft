using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautiSoft.Models.Entidades
{
    public class Cliente
    {
        [Key]
        [Required(ErrorMessage = "El Documento es requeridos")]
        [Range(9999, 999999999999999, ErrorMessage = "Documento inválido")]
        public string Documento { get; set; }

        [Required(ErrorMessage = "El nombre y los apellidos son requeridos")]
        public string Nombre { get; set; }
        public string Dirreccion { get; set; }

        [Required(ErrorMessage = "El email es requerido")]
        [EmailAddress(ErrorMessage = "El email es inválido")]
        public string Correo { get; set; }

        [Required(ErrorMessage = "el telefono es requerido.")]
        public string Telefono { get; set; }
        public bool Estado { get; set; }

        [Required(ErrorMessage = "El tipo de documento es requerido")]
        public Guid TipoDocumentoId { get; set; }
        public virtual List<Cita> Citas { get; set; }
    }
}

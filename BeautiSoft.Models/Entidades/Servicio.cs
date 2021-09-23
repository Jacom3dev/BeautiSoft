using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautiSoft.Models.Entidades
{
    public class Servicio
    {
        [Key]
        public Guid ServicioID { get; set; }
        [Required(ErrorMessage = "El Nombre del Servicio es requerido")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El detalle es requerido")]
        public string Detalle { get; set; }
        public bool Estado { get; set; }
        public virtual List<DetalleCita> DetalleCitas { get; set; }
    }
}

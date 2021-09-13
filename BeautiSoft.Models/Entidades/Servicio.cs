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
        public string Nombre { get; set; }
        public string Detalle { get; set; }
        public bool Estado { get; set; }
        public virtual List<DetalleCita> DetalleCitas { get; set; }
    }
}

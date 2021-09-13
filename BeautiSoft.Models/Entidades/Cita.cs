using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautiSoft.Models.Entidades
{
    public class Cita
    {
        [Key]
        public Guid CitaID { get; set; }
        public DateTime Fecha { get; set; }
        public string Lugar { get; set; }
        public virtual List<DetalleCita> DetalleCitas { get; set; }
    }
}

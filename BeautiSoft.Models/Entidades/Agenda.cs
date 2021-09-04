using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautiSoft.Models.Entidades
{
    public class Agenda
    {
        [Key]
        public Guid CitaID { get; set; } 
        public DateTime Fecha { get; set; }
        public Guid ServicioID { get; set; }
        public virtual ServicioOfrecido Servicio { get; set; }
        public string Documento { get; set; }
        public virtual Cliente Cliente { get; set; }
        public string Lugar { get; set; }
    }
}

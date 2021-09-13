using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautiSoft.Models.Entidades
{
    public class DetalleCita
    {
        public Guid DetalleCitaID { get; set; }
        public Guid CitaID { get; set; }
        public Guid ServicioID { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautiSoft.Models.Entidades
{
    public class TipoDocumento
    {
        [Key]
        public Guid TipoDocumentoId { get; set; }
        public string Nombre { get; set; }

        public virtual List<Cliente> Clientes { get; set; }
    }
}

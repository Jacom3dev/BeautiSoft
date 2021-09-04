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
        public string Documento { get; set; }
        public string Nombre { get; set; }
        public string Dirreccion { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public bool Estado { get; set; }
        public Guid TipoDocumentoId { get; set; }
        public virtual TipoDocumento TipoDocumento { get; set; }
        public virtual List<Cliente> Clientes { get; set; }
    }
}

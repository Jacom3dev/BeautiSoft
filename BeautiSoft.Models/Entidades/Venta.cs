using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautiSoft.Models.Entidades
{
    public class Venta
    {
        [Key]
        public Guid VentaId { get; set; }
        
        [Required(ErrorMessage = "El Producto  es requerido")]
        public Guid ProductoID { get; set; }
        public virtual Producto Producto { get; set; }
        //[Required(ErrorMessage = "El documento  es requerido")]
        //[Range(9999, 999999999999999, ErrorMessage = "Documento inválido")]
        public string ClienteDocumento { get; set; }
        public virtual Cliente Cliente { get; set; }
        [Required(ErrorMessage = "La Cantidad  es requerida")]
        public int Cantidad { get; set; }
        [Required(ErrorMessage = "El Precio  es requerido")]
        public double Precio { get; set; }

        

    }
}

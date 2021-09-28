using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautiSoft.Models.Entidades
{
    public class Compra
    {
        [Key]
        public Guid CompraID { get; set; }
        [Required(ErrorMessage = "El Precio  es requerido")]
        public double Precio { get; set; }
        [Required(ErrorMessage = "Lacantidad  es requerida")]
        public int Cantidad { get; set; }
        public DateTime  Fecha { get; set; }
        [Required(ErrorMessage = "El Producto   es requerido")]
        public Guid ProductoID { get; set; }
        public virtual Producto Producto { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautiSoft.Models.Entidades
{
    public class Producto
    {
        [Key]
        public Guid ProductoID { get; set; }
        [Required(ErrorMessage = "El Nombre es requerido")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El Precio es requerido")]
        public double Precio { get; set; }
        [Required(ErrorMessage = "La Cantidad  es requerida")]
        public int Cantidad { get; set; }
        public string Imagen { get; set; }
        public bool Estado { get; set; }
        public virtual List<Compra> Compras { get; set; }
        public virtual List<Venta> Ventas { get; set; }
    }
}

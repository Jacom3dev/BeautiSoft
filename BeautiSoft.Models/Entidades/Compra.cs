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
        public double Precio { get; set; }
        public int Cantidad { get; set; }
        public DateTime  Fecha { get; set; }
        public Guid ProductoID { get; set; }
        public virtual Producto Producto { get; set; }
    }
}

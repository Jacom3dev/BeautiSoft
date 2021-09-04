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
        public string Nombre { get; set; }
        public double Precio { get; set; }
        public int Cantidad { get; set; }
        public string Imagen { get; set; }
        public bool Estado { get; set; }
        public virtual List<Producto> Productos { get; set; }

    }
}

using BeautiSoft.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautiSoft.Servicios.Interfaces
{
    public interface IProductoServicios
    {
        void Crear(Producto producto);
        Task<IEnumerable<Producto>> ListarProductos();
        void ActualizarProducto(Producto producto);
        Task<Producto> GetProductoID(Guid ProductoID);
        Task<bool> GuardarCambios(); 
    }

}

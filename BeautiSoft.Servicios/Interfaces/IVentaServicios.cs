using BeautiSoft.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautiSoft.Servicios.Interfaces
{
    public interface IVentaServicios
    {
        Task<IEnumerable<Cliente>> Documentos();
        Task<IEnumerable<Producto>> Productos();
        Task<IEnumerable<Venta>> ListarVentas();
        void Crear(Venta venta);
        Task<Venta> GetVentaId(Guid VentaID);
        void Editar(Venta venta);
        Task<bool> GuardarCambios();
    }
}
